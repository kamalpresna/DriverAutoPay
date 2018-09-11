using AutoMapper;
using CARS.Data.DataAccess;
using CARS.Service;
using log4net;
using PayTNCDriver.Model;
using PayTNCDriver.Repositories.Concrete;
using PayTNCDriver.Utils.Mappings;
using ReportLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;
using Telerik.Reporting;
using Telerik.Reporting.Processing; 
using System.Linq;
using PayTNCDriver.Enums;
using AutoMapper.Configuration;

namespace PayTNCDriver
{
    public class Program
    {
        private static readonly ILog _logger = new LogHandler().GetLogger();


        static void Main(string[] args)
        {
            /*
            1. Daily midnight - create new tnc pay period for each newly active TNC Driver from previous sun 12:00AM to Saturday 23:59PM
            2. Send the daily fare summary to the TNC on
            3. Once TNC Driver is booked, rebook every Saturday at 23:59:59
            4. After rebook, send out fare summary for pay period
            5. Every Wed , pay or charge the TNC Driver for the balance as of previous Sunday 12:00AM or earlier
            6. Send receipts for details after step 5
            7. Prevent other process that changes status' from affecting TNC
            */
            try
            {
                List<DriverFares> drFares = DataAccess.GetDriverFaresForAutoPay();
                Voucher vo = new Voucher();
                //Started Pushing all pending fares for all Discount ride drivers to journals
                _logger.Info(String.Format("{0}", "Started Pushing all pending fares for all Discount ride drivers to journals"));
                foreach (var fare in drFares)
                {
                    vo.PayDriverFares(fare.DriverChargeID, Convert.ToInt32(ConfigurationManager.AppSettings["Location"]), ConfigurationManager.AppSettings["Cashier"]);
                    _logger.Info(String.Format("{0} {1}", fare.DriverChargeID, "Completed"));
                }
                _logger.Info(String.Format("{0}", "Completed Pushing all pending fares for all Discount ride drivers to journals"));

                //Step 5 
                _logger.Info(String.Format("{0} {1}", "Auto Payments for TNC Drivers started : ", DateTime.Now.ToString()));
                List<DriverInfo> tncDrivers = DataAccess.GetTNCDrivers();
                List<DriverInfo> achDrivers = DataAccess.GetACHDrivers();
                List<DriverInfo> paypalDrivers = DataAccess.GetPayPalDrivers();
                DriverService ds = new DriverService();
                var driverCard = new Pay();
                var baseMappings = new MapperConfigurationExpression();
                baseMappings.CreateMap<UserHPPProfile, UserHPPProfileBindingModel>();
                var config = new MapperConfiguration(baseMappings);
                IMapper mapper = new Mapper(config);

                var driverPayACH = new DriverPayACH(new WalletRepository(), mapper);

                //Testing purpose only
                //DriverInfo owner = new DriverInfo();
                //owner.DriverID = Convert.ToInt32(ConfigurationManager.AppSettings["TestDriver"]);
                //owner.EmailAddress = ConfigurationManager.AppSettings["TestEmail"];
                //GenerateReceipt(owner);

                foreach (var driver in tncDrivers)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(driver.CardProxyNumber)) continue;

                        if (driver.CardBalance == 0) continue;

                        GenerateReceipt(driver);

                        if (driver.CardBalance > 0)
                        {
                            _logger.Info(String.Format("{0} {1} {2} {3}", "PayDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                            driverCard.PayDriver(driver.CardBalance, driver);
                        }
                        else
                        {
                            _logger.Info(String.Format("{0} {1} {2} {3}", "ChargeDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                            driverCard.ChargeDriver(driver.CardBalance, driver);
                        }
                        ds.ReconcileDriverAR(driver.DriverID, driver.LocationID, ConfigurationManager.AppSettings["Cashier"]);

                    }
                    catch (Exception ex)
                    {
                        _logger.Info("Error during Card AutoPay for driver: " + driver.DriverNumber);
                        _logger.Error(ex);

                    }
                }

                //***PAYPAL****///
                bool hasOneToProcessPP = false;
                hasOneToProcessPP = paypalDrivers.Count > 0;

                if (hasOneToProcessPP)
                {
                    var payPalTransaction = new Pay();
                    payPalTransaction.ProcessPayPalDrivers(paypalDrivers);
                    foreach (var driver in paypalDrivers)
                    {
                        _logger.Info(String.Format("{0} {1} {2}", "driver.ReadyToProcess: ", driver.ReadyToProcess, driver.DriverNumber));
                        if (driver.CardBalance != 0 && driver.ReadyToProcess == 1)
                        {
                            _logger.Info(String.Format("{0} {1} {2}", "ReconcileDriverAR: ", driver.DriverID, driver.DriverNumber));
                            ds.ReconcileDriverAR(driver.DriverID, driver.LocationID, ConfigurationManager.AppSettings["Cashier"]);
                        }
                    }

                    //Generate Receipts
                    foreach (var driver in paypalDrivers)
                    {
                        try
                        {
                            if (driver.CardBalance == 0) continue;

                            GenerateReceipt(driver);

                            if (driver.CardBalance > 0)
                            {
                                _logger.Info(String.Format("{0} {1} {2} {3}", "PayPalDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                                driver.Type = (short)TransactionTypes.Debit; // Debit TotalRide
                            }
                            else
                            {
                                _logger.Info(String.Format("{0} {1} {2} {3}", "ChargePayPalDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                                driver.Type = (short)TransactionTypes.Credit; // Credit TotalRide with the amount
                            }

                            driver.ReadyToProcess = 1;
                        }
                        catch (Exception ex)
                        {
                            string error = "Error during PayPal AutoPay for driver: " + driver.DriverNumber.ToString();
                            _logger.Info(error);
                            _logger.Error(ex);
                            DataAccess.LogError(driver.DriverID, error, ex.ToString().Substring(0, 3999));
                        }
                    }
                }

                ///***ACH * ***///
                bool hasOneToProcess = false;
                foreach (var driver in achDrivers)
                {
                    try
                    {
                        if (driver.CardBalance == 0) continue;

                        var userProfile = driverPayACH.GetUserUserHPPProfiles(driver.DriverID);
                        //_logger.Info(String.Format("{0} {1} {2} {3}", "ChargeACHDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                        driver.FirstName = userProfile.FirstName;
                        driver.LastName = userProfile.LastName;

                        String PrimaryHPPProfileID = DataAccess.GetHPPProfileID(driver.DriverID).ToString();
                        var chaseProfile = driverPayACH.GetHPPProfile(PrimaryHPPProfileID); // updated to use the promarty instead of just one in the list: userProfile.HPPProfileId
                        driver.RoutingNumber = chaseProfile.RoutingNumber;
                        driver.AccountNumber = chaseProfile.AccountNumber;

                        //_logger.Info(String.Format("For Each ACH Driver");
                        GenerateReceipt(driver);
                        //_logger.Info(String.Format("Generated Recipt For Driver Number: {0} {1} {2} {3}", "ChargeACHDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));

                        if (driver.CardBalance > 0)
                        {
                            _logger.Info(String.Format("{0} {1} {2} {3}", "PayACHDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                            driver.Type = (short)TransactionTypes.Debit; // Debit TotalRide
                        }
                        else
                        {
                            _logger.Info(String.Format("{0} {1} {2} {3}", "ChargeACHDriver: ", driver.DriverNumber, "Amount: ", driver.CardBalance));
                            driver.Type = (short)TransactionTypes.Credit; // Credit TotalRide with the amount
                        }
                        hasOneToProcess = true;
                        driver.ReadyToProcess = 1;
                    }
                    catch (Exception ex)
                    {
                        string error = "Error during ACH AutoPay for driver: " + driver.DriverNumber.ToString();
                        _logger.Info(error);
                        _logger.Error(ex);
                        DataAccess.LogError(driver.DriverID, error, ex.ToString().Substring(0, 3999));
                    }
                }
                if (hasOneToProcess)
                {
                    driverPayACH.ProcessACHTransactionList(achDrivers);
                    foreach (var driver in achDrivers)
                    {
                        _logger.Info(String.Format("{0} {1} {2}", "driver.ReadyToProcess: ", driver.ReadyToProcess, driver.DriverNumber));
                        if (driver.CardBalance != 0 && driver.ReadyToProcess == 1)
                        {
                            _logger.Info(String.Format("{0} {1} {2}", "ReconcileDriverAR: ", driver.DriverID, driver.DriverNumber));
                            ds.ReconcileDriverAR(driver.DriverID, driver.LocationID, ConfigurationManager.AppSettings["Cashier"]);
                        }
                    }
                }
            }
			catch (Exception ex)
            {
                _logger.Info(String.Format("{0} {1}", "Error during clearing pending fares : ", ex.Message));
                _logger.Error(ex);
            }
            _logger.Info(String.Format("{0} {1}", "Auto Payments for TNC Drivers completed : ", DateTime.Now.ToString()));
        }


        static void SaveReceipt(Telerik.Reporting.Report report, string fileName)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = report;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);
            _logger.Info(String.Format("{0}", "TR Driver receipt rendered successfully."));

            //Save receipt in azure blob storage
            DriverPhotoService driverPhotoService = new DriverPhotoService(ConfigurationManager.ConnectionStrings["AzureBlobs"].ConnectionString);
            var receiptUpload = driverPhotoService.UploadReceipt(fileName + ".pdf", "application/pdf", result.DocumentBytes);

            _logger.Info(String.Format("{0}", "TR Driver receipt saved successfully."));

        }

        static void GenerateReceipt(DriverInfo dr)
        {
            _logger.Info(String.Format("{0} {1}", "DR Driver receipt generating for : ", dr.DriverNumber));
            TRReceipts drReceipt = new TRReceipts();
            drReceipt.ReportParameters["DriverID"].Value = dr.DriverID; 
            drReceipt.ReportParameters["DriverBalance"].Value = dr.CardBalance;

            string fileName = String.Format("{0}_{1}", dr.DriverNumber, DateTime.Now.ToString("yyyyMMddHHmmss"));
            drReceipt.Report.Name = fileName;

            _logger.Info(String.Format("{0} {1}", "TR Driver receipt, saving receipt for : ", dr.DriverNumber));
            SaveReceipt(drReceipt, fileName);
            _logger.Info(String.Format("{0} {1}", "TR Driver receipt generated for : ", dr.DriverNumber));
            MailReceipt(drReceipt, dr.EmailAddress);
            _logger.Info(String.Format("{0} {1}", "TR Driver receipt emailed to ", dr.DriverNumber));
        }

        static void MailReceipt(Telerik.Reporting.Report report, string ownerEmail)
        {
            ReportProcessor reportProcessor = new ReportProcessor();
            Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource.ReportDocument = report;
            RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

            MemoryStream ms = new MemoryStream(result.DocumentBytes);
            ms.Position = 0;

            Attachment attachment = new Attachment(ms, report.Name + ".pdf");
            string from = ConfigurationManager.AppSettings["From"];
            // string to = ConfigurationManager.AppSettings["To"];
            string subject = ConfigurationManager.AppSettings["Subject"];
            string body = ConfigurationManager.AppSettings["Body"];
            MailMessage msg = new MailMessage(from, ownerEmail, subject, body);
            msg.Attachments.Add(attachment);
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPHost"], int.Parse(ConfigurationManager.AppSettings["SMTPPort"]));
            client.Send(msg);
        }

        static void DeletePDF()
        {
            var files = new DirectoryInfo("./Fares/").GetFiles("*.pdf");
            int daysCount = Convert.ToInt16(ConfigurationManager.AppSettings["DeleteFile"]);
            foreach (var file in files)
            {
                if (DateTime.UtcNow - file.CreationTimeUtc > TimeSpan.FromDays(daysCount))
                {
                    File.Delete(file.FullName);
                }
            }

        }
    }
}
