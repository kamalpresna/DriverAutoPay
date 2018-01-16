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

            using (var context = _context)
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

					foreach (var vt in achTransactionList)
                    {
						if (vt.CardBalance == 0) continue;

						short Type = vt.Type;
                        int transactionTypeID = Type == 0 ? transactionTypeIdAchCredit.Value : transactionTypeIdAchDebit.Value;
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
                                Amount = _.CardBalance,
                                AccountNumber = _.AccountNumber,
                                RoutingNumber = _.RoutingNumber,
                                FullName =  _.FirstName + " " + _.LastName
                            })
                            .ToList();
                        
                        // Create journal entries
                        CARS.Data.DataAccess.Journal jl = new CARS.Data.DataAccess.Journal();

						foreach (var vt in achTransactionList)
                        {
							if (vt.CardBalance == 0) continue;

							int locationID = vt.LocationID;
                            int journalID = jl.GetJournalAccountID(1, locationID);
                            decimal credit = vt.Type == 1 ? vt.CardBalance : 0;
                            decimal debit = vt.Type == 0 ? vt.CardBalance : 0;
							int transactionTypeID = vt.Type == 0 ? transactionTypeIdAchCredit.Value : transactionTypeIdAchDebit.Value;
                            int journalAccount = journalAccounts[(transactionTypeID, locationID)];
							//create Journal entry

							JournalItem ji = new JournalItem
                            {
                                LocationID = locationID,
                                JournalID = journalID,
                                TransactionTypeID = transactionTypeID,
                                ReversalID = transactionTypeID,
                                DriverID = vt.DriverID,
                                Credit = credit,
                                Debit = debit,
                                Description = transactionTypeID == transactionTypeIdAchCredit.Value ? "ACH Settlement to Driver" : "ACH Settlement from Driver",
                                CreatedBy = ConfigurationManager.AppSettings["Cashier"], /// Need to be defined
                                JournalID2 = journalAccount
                            };

							jl.AddJournalEntry(ji);

							var driver = _context.Drivers.Single(_ => _.DriverID == vt.DriverID);
                            driver.ACHAmountOnHold -= vt.CardBalance;
                            driver.ACHAmountOnHoldCreated = DateTime.Now;
                            driver.ACHAmountOnHoldCreatedBy = ConfigurationManager.AppSettings["Cashier"];

							AchTransaction achTransaction = new AchTransaction
                            {
                                AccountNumber = Crypto.AES.EncryptString(vt.AccountNumber),
                                RoutingNumber = Crypto.AES.EncryptString(vt.RoutingNumber),
                                Amount = vt.CardBalance,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now,
                                DriverID = vt.DriverID,
                                Processed = false,
                                Type = vt.Type,
                                CreatedBy = ConfigurationManager.AppSettings["Cashier"],
                                ModifiedBy = ConfigurationManager.AppSettings["Cashier"]
                            };
                            _logger.Info(vt.AccountNumber);
                            _logger.Info(vt.RoutingNumber);
                            _context.AchTransactions.Add(achTransaction);
                            _context.SaveChanges();

                            vt.TransactionId = achTransaction.TransactionID;
                        }
                       
                        var batchNumber = _context.AchTransactions.Max(_ => _.BatchNumber ?? 0) + 1;

						var nachaFile = NachaFile.FromAchTransactions(validNachaAchTransactions, "Payroll-TT", batchNumber);

                       
                        if (TypedSettings.PerformAchTransaction)
                        {
                           
                            // encrypt
                            string certificateRootFolder = Globals.GetString("ChaseCertificateRootFolder");

                            string tempFolder = Globals.GetString("TempFolder");

                            string nachaFileName = "TOTALTRANSIT.ACH.NACHA." + batchNumber.ToString("D5");

                            string tempFileName = Path.Combine(tempFolder, nachaFileName);  
                            using (StreamWriter writer = new StreamWriter(File.OpenWrite(tempFileName)))
                            {
                                nachaFile.Write(writer);
                            }                         
                            MemoryStream encryptedFile = NachaFile.EncryptAndSign(certificateRootFolder, tempFileName);

                            string signedFileName = tempFileName + ".signed";
                            File.WriteAllBytes(signedFileName, encryptedFile.ToArray());

                          
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

                            File.Delete(tempFileName);
                            File.Delete(signedFileName);
                        }

						// update database
						foreach (var achTransaction in achTransactionList)
                        {
                            var dbTransaction = _context.AchTransactions.Single(_ => _.TransactionID == achTransaction.TransactionId);
                            dbTransaction.ModifiedBy = ConfigurationManager.AppSettings["Cashier"];
                            dbTransaction.DateModified = DateTime.Now;


							dbTransaction.BatchNumber = batchNumber;
                                dbTransaction.Processed = true;
                                dbTransaction.DateProcessed = DateTime.Now;
                                dbTransaction.ProcessedBy = ConfigurationManager.AppSettings["Cashier"];

                        }                       
                        _context.SaveChanges();
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
