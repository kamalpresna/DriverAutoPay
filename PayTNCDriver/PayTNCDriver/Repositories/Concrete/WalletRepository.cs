using PayTNCDriver.Model;
using PayTNCDriver.Repositories.Abstract;
using PayTNCDriver.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS.Data.DataAccess;
using CARS.Utilities.Ach;
using CARS.Utilities;
using CARS.Data.Entity;
using System.IO;
using PayTNCDriver.Classes;
using WinSCP;
using log4net;
using System.Configuration;
using PayTNCDriver.Enums;

namespace PayTNCDriver.Repositories.Concrete
{
    public class WalletRepository : Repository<CARSEntities, UserHPPProfile>, IWalletRepository
    {
        private static readonly ILog _logger = new LogHandler().GetLogger();
        public WalletRepository(CARSEntities context) : base(context)
        {
        }

        public WalletRepository() : this(new CARSEntities())
        {

        }   
        
        public UserHPPProfileDTO FindByUserId(int userId)
        {

            using (var context = GetContext())
            {
                var userAssociation = context.UsersAssociations.Where(t => t.CarsUserID == userId).FirstOrDefault();
                var contact = (from d in context.Drivers where d.DriverID == userId from c in context.Contacts where d.ContactID == c.ContactID select c ).FirstOrDefault();
                return context.UserHPPProfiles.Where(t => t.UserId == userAssociation.PortalUserID).Select(t=> new UserHPPProfileDTO {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    FriendlyName = t.FriendlyName,
                    HPPProfileId = t.HPPProfileId,
                    PrimaryProfile = t.PrimaryProfile,
                    UserId = t.UserId
                }).FirstOrDefault();
            }            
        }

        public Model.UserHPPProfile FindByUserIdAndHPPProfileId(string userId, string hppProfileId)
        {
            return _context.UserHPPProfiles.FirstOrDefault(hpp => hpp.UserId == userId && hpp.HPPProfileId == hppProfileId);
        }


        public Model.UserHPPProfile FindByHPPProfileId(string hppProfileId)
        {
            return GetContext().UserHPPProfiles.FirstOrDefault(hpp => hpp.HPPProfileId == hppProfileId);        
        }


        public Model.PaymentType FindPaymentTypeById(int? paymentTypeId)
        {
            return _context.PaymentTypes.FirstOrDefault(pt => pt.PaymentTypeID == paymentTypeId);
        }

        public bool HasHPPProfilesInDatabase(string userId)
        {
            return _context.UserHPPProfiles.Any(hpp => hpp.UserId == userId);
        }

        public bool HPPProfileIdExistsInDatabase(string hppProfielId)
        {
            return _context.UserHPPProfiles.FirstOrDefault(hpp => hpp.HPPProfileId == hppProfielId) != null;
        }

        public bool HPPProfileIdExistsInPaymentech(string userId, string hppProfileId)
        {
            return true;
        }

        public void ProcessAchTransactions( IList<DriverInfo> achTransactionList)
        {           
            try
            {
               
                //using (TransactionScope transaction = new TransactionScope())
                {
					_context = GetContext();
					_logger.Info(String.Format("Got Context"));
					int? transactionTypeIdAchCredit = _context.TransactionTypes.SingleOrDefault(_ => _.TransactionType1 == "ACH Settlement to Driver")?.TransactionTypeID;
                    if (transactionTypeIdAchCredit == null)
                        throw new Exception("Transaction type 'ACH Settlement to Driver' is not configured. Contact administrator.");
                   
                    int? transactionTypeIdAchDebit = _context.TransactionTypes.SingleOrDefault(_ => _.TransactionType1 == "ACH Settlement from Driver")?.TransactionTypeID;
                   
                    if (transactionTypeIdAchDebit == null)
                        throw new Exception("Transaction type 'ACH Settlement from Driver' is not configured. Contact administrator.");
                   
                    // validate JournalAccountID for 
                    Dictionary<(int, int), int> journalAccounts = new Dictionary<(int, int), int>();
                   
                    int? accountType = _context.AccountTypes.SingleOrDefault(_ => _.AccountType1 == "Card")?.AccountTypeID;
                    if (!accountType.HasValue)
                        throw new Exception("Account type 'Card' is not configured. Contact administrator.");

					//_logger.Info(String.Format("For Each achTransactionList"));
					foreach (var vt in achTransactionList)
                    {
						if (vt.CardBalance == 0 || vt.ReadyToProcess != 1) continue;

						short Type = vt.Type;
                        int transactionTypeID = vt.Type == 0 ? transactionTypeIdAchCredit.Value : transactionTypeIdAchDebit.Value;
                        int locationID = vt.LocationID;
                        if (!journalAccounts.ContainsKey((transactionTypeID, locationID)))
                        {
                            int? journalAcount = _context.JournalAccounts
                                .FirstOrDefault(_ => _.TransactionTypeID == transactionTypeID
                                                     && _.LocationID == locationID
                                                     && ((_.AccountType & 1) == 1 || _.AccountType == accountType))?.JournalID;
                            if (!journalAcount.HasValue)
                                throw new Exception($"Journal account is not configured for TransactionType {transactionTypeID} and Location {locationID}. Contact administrator.");

                            journalAccounts.Add((transactionTypeID, locationID), journalAcount.Value);
                        }
                    }
					if (achTransactionList.Any())
                    {
                        var validNachaAchTransactions = achTransactionList
                            .Select(_ => new NachaFile.AchTransactionInfo
                            {
                                Type = _.Type,
                                Amount = Math.Abs(_.CardBalance),
                                AccountNumber = _.AccountNumber,
                                RoutingNumber = _.RoutingNumber,
                                FullName =  _.FirstName + " " + _.LastName
                            }) //.Where(Amount != 0)
                            .ToList();

						// Create journal entries
						CARS.Data.DataAccess.Journal jl = new CARS.Data.DataAccess.Journal();

						foreach (var vt in achTransactionList)
                        {
							if (vt.CardBalance == 0 || vt.ReadyToProcess != 1) continue;

							decimal ABSAmount = Math.Abs(vt.CardBalance);

							int locationID = vt.LocationID;
                            int journalID = jl.GetJournalAccountID(1, locationID);
                            decimal credit = vt.Type == 1 ? ABSAmount : 0;
                            decimal debit = vt.Type == 0 ? ABSAmount : 0;
							int transactionTypeID = vt.Type == 0 ? transactionTypeIdAchCredit.Value : transactionTypeIdAchDebit.Value;
							int journalAccount = journalAccounts[(transactionTypeID, locationID)];
							//create Journal entry
                            //_logger.Info(String.Format("Journal: {0} {1} ",));
                            JournalItem ji = new JournalItem
                            {
                                LocationID = locationID,
                                JournalID = journalID,
                                TransactionTypeID = 1,
                                ReversalID = transactionTypeID,
                                DriverID = vt.DriverID,
                                Credit = credit,
                                Debit = debit,
                                Description = transactionTypeID == transactionTypeIdAchCredit.Value ? "ACH Settlement to Driver" : "ACH Settlement from Driver",
                                CreatedBy = ConfigurationManager.AppSettings["Cashier"], /// Need to be defined
                                DateCreated = DateTime.Now,
                                PaymentTypeID = (int)Enums.PaymentType.ach,
                                Cleared = false,
                                JournalID2 = journalAccount
                            };

                            jl.AddJournalEntry(ji);

							var driver = _context.Drivers.Single(_ => _.DriverID == vt.DriverID);
                            driver.ACHAmountOnHold -= ABSAmount;
                            driver.ACHAmountOnHoldCreated = DateTime.Now;
                            driver.ACHAmountOnHoldCreatedBy = ConfigurationManager.AppSettings["Cashier"];

							AchTransaction achTransaction = new AchTransaction
                            {
                                AccountNumber = Crypto.AES.EncryptString(vt.AccountNumber),
                                RoutingNumber = Crypto.AES.EncryptString(vt.RoutingNumber),
                                Amount = ABSAmount,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now,
                                DriverID = vt.DriverID,
                                Processed = false,
                                Type = vt.Type,
                                CreatedBy = ConfigurationManager.AppSettings["Cashier"],
                                ModifiedBy = ConfigurationManager.AppSettings["Cashier"]
                            };
                            _logger.Info(String.Format("ABS Amount: {0} -- Type: {1}",achTransaction.Amount, achTransaction.Type));
                            _context.AchTransactions.Add(achTransaction);
                            _context.SaveChanges();
							//_logger.Info(String.Format("Saved Changes"));

							vt.TransactionId = achTransaction.TransactionID;
						}

						var batchNumber = _context.AchTransactions.Max(_ => _.BatchNumber ?? 0) + 1;
						//_logger.Info(String.Format("Batch"));

						//_logger.Info(String.Format("BatchNUm: {0}", batchNumber));
						//_logger.Info(String.Format("validNachaAchTransactions {0}", validNachaAchTransactions.Count));
						//Type = _.Type,
						//                          Amount = Math.Abs(_.CardBalance),
						//                          AccountNumber = _.AccountNumber,
						//                          RoutingNumber = _.RoutingNumber,
						//                          FullName = _.FirstName + " " + _.LastName
						//						var Json = JsonConvert
						//_logger.Info(String.Format("validNachaAchTransactions Type {0}", validNachaAchTransactions[0].Type));
						//_logger.Info(String.Format("validNachaAchTransactions Amount {0}", validNachaAchTransactions[0].Amount));
						//_logger.Info(String.Format("validNachaAchTransactions AccountNumber {0}", validNachaAchTransactions[0].AccountNumber));
						//_logger.Info(String.Format("validNachaAchTransactions RoutingNumber {0}", validNachaAchTransactions[0].RoutingNumber));
						//_logger.Info(String.Format("validNachaAchTransactions FullName {0}", validNachaAchTransactions[0].FullName));
						var nachaFile = NachaFile.FromAchTransactions(validNachaAchTransactions, "Payroll-TT", batchNumber);
						//_logger.Info(String.Format("nachaFile"));


						if (TypedSettings.PerformAchTransaction)
                        {
							// encrypt
							//_logger.Info(String.Format("Get Global"));
							string certificateRootFolder = Globals.GetString("ChaseCertificateRootFolder");
							_logger.Info(String.Format("certificateRootFolder: {0}", certificateRootFolder));
							string tempFolder = Globals.GetString("TempFolder");
							_logger.Info(String.Format("Temp fldr: {0}", tempFolder));
							string nachaFileName = "TOTALTRANSIT.ACH.NACHA." + batchNumber.ToString("D5");
							_logger.Info(String.Format("Write the Nacha file to the temp folder"));
							string tempFileName = Path.Combine(tempFolder, nachaFileName);
							_logger.Info(String.Format("Temp filename: {0}", tempFileName));
							using (StreamWriter writer = new StreamWriter(File.OpenWrite(tempFileName)))
                            {
                                nachaFile.Write(writer);
                            }

							_logger.Info(String.Format("Sign and Encrypt the Nacha file"));
							MemoryStream encryptedFile = NachaFile.EncryptAndSign(certificateRootFolder, tempFileName);

                            string signedFileName = tempFileName + ".signed";
                            File.WriteAllBytes(signedFileName, encryptedFile.ToArray());


							_logger.Info(String.Format("-- 4 --"));
							// send
							SessionOptions options = new SessionOptions
                            {
                                Protocol = Protocol.Sftp,
                                HostName = NachaFile.HostName,
                                UserName = "TOTALTRANSIT",
                                PrivateKeyPassphrase = "TotalTransit2016",
                                SshPrivateKeyPath = Path.Combine(certificateRootFolder, "chase.ppk"),

                                SshHostKeyFingerprint = NachaFile.SshHostKeyFingerprint
                            };
                          
                            using (Session session = new Session())
                            {
                               
                                session.Open(options);

                                TransferOptions transferOptions = new TransferOptions
                                {
                                    TransferMode = TransferMode.Binary
                                };

								var transferResult = session.PutFiles(signedFileName, $"/Inbound/Encrypted/{nachaFileName}.signed", false, transferOptions);
                              
                                // Throw on any error
                                transferResult.Check();

                                //// Print results
                                //foreach (TransferEventArgs transfer in transferResult.Transfers)
                                //{
                               
                                //}
                            }

							//_logger.Info(String.Format("-- 8 --"));
							File.Delete(tempFileName);
                            File.Delete(signedFileName);
                        }                      
                        // update database
                        foreach (var vt in achTransactionList)
                        {
							if (vt.CardBalance == 0 || vt.ReadyToProcess != 1) continue;
							//_logger.Info(String.Format("For Each Before _context.AchTransactions.Single"));
							var dbTransaction = _context.AchTransactions.Single(_ => _.TransactionID == vt.TransactionId);
							//_logger.Info(String.Format("For Each After _context.AchTransactions.Single"));
							dbTransaction.ModifiedBy = ConfigurationManager.AppSettings["Cashier"];
                            dbTransaction.DateModified = DateTime.Now;


							dbTransaction.BatchNumber = batchNumber;
                                dbTransaction.Processed = true;
                                dbTransaction.DateProcessed = DateTime.Now;
                                dbTransaction.ProcessedBy = ConfigurationManager.AppSettings["Cashier"];

                        }
						//_logger.Info(String.Format("Before Save"));
						_context.SaveChanges();
						//_logger.Info(String.Format("After Save"));
					}


				}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
