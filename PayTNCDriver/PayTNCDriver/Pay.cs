using System;
using System.Configuration;
using CARS.Data.Entity;
using CARS.Service;
using log4net;
using PayTNCDriver.Model;


namespace PayTNCDriver
{  
    public class Pay
    {       
        private static readonly ILog _logger = new LogHandler().GetLogger();
        DriverService ds = new DriverService();
        Random rnd = new Random();

        public void PayDriver(decimal amount, DriverInfo di)
        {

            DriverPayLoad driverPayCard = new DriverPayLoad();
            driverPayCard.agentId = ConfigurationManager.AppSettings["BusinessPartnerId"];
            driverPayCard.channelType = ConfigurationManager.AppSettings["ChannelType"];
            driverPayCard.currencyCode = ConfigurationManager.AppSettings["CurrencyCode"];
            driverPayCard.refId = ConfigurationManager.AppSettings["RefId"];

            driverPayCard.sourceTxnId = Convert.ToString(rnd.Next());

            driverPayCard.transactionAmount = (amount * 100).ToString("#.##");
            driverPayCard.sourceName = ConfigurationManager.AppSettings["SourceName"];
            driverPayCard.sourceTxnDateTime = DateTime.Now.ToString("yyyy-MM-dd");

            DriverPayAPI reqCard = new DriverPayAPI();
            _logger.Debug("Calling Driver Pay card load API");
            DriverPayLoadResponse loadCardResponse = null;
            try
            {
                loadCardResponse = reqCard.LoadCard(driverPayCard, di);

            }
            catch (Exception ex)
            {
                _logger.Error("Exception in loading driver pay card : " + di.DriverNumber);
                _logger.Error("Exception in details are : " + ex.Message);
            }

            if (loadCardResponse != null && loadCardResponse.errorDetails[0].errorCode == "0")
            {
                try
                {
                    //Add notes for Driver
                    string notes = String.Format("{0} {1} {2}", "Pay Card loaded Successfully", " ", amount.ToString("#.##"));
                    NoteItem ni = new NoteItem() { Note = notes };
                    if (di.DriverNumber != null)
                        ni.RelatedID = di.DriverID;
                    ni.NoteTypeID = 1;
                    ni.CreatedBy = ConfigurationManager.AppSettings["Cashier"];
                    ds.ModifyNotes(ni);
                    _logger.Debug("Added driver notes for driver payment: " + di.DriverNumber);

                }
                catch (Exception ex)
                {
                    _logger.Error("Exception in updating driver notes : " + di.DriverNumber);
                    _logger.Error("Exception in details are : " + ex.Message);
                }

                try
                {
                    TransactionTypeItem tt = ds.GetTransactionTypeItemByName("Pay the Driver Card");

                    //decimal EndingBalance = 0;

                    //EndingBalance += AddAmount(lblEndingBalance);
                    ////adjust ending balance for hand helds
                    //EndingBalance += AddAmount(lblHandHeld);
                    ////adjust ending balance for vouchers
                    //EndingBalance += AddAmount(lblPaidVouchers);
                    ////adjust ending balance for credit cards
                    //EndingBalance += AddAmount(lblPaidCards);
                    ////adjust ending balance for service charges
                    //EndingBalance += AddAmount(lblAppliedCharge);

                    decimal Amount = amount;// Helper.StringToDecimal(endingBalance);
                    if (Amount <= 0)
                    {
                        //lblErrorMessage.Text = "Invalid Charge Amount Entered!";
                        return;
                    }

                    //if (tt.TransactionTypeID == 21) //Cashout limit
                    //    if (Amount > EndingBalance)
                    //    {
                    //        //lblErrorMessage.Text = "Amount Exceeds your Cash out Limit.";
                    //        return;
                    //    }

                    const decimal ARCredit = 0;
                    decimal ARDebit = 0;

                    ARDebit = Amount;

                    //create Journal entry
                    JournalItem ji = new JournalItem();
                    //TransactionTypeItem tt = ds.GetTransactionTypeItemByName("Pay the Driver Card");
                    int LocationID = 0;

                    //if (Session["LocationID"] != null)
                    LocationID = 1;
                    ji.LocationID = LocationID;
                    ji.JournalID = ds.GetJournalAccountID(1, LocationID);
                    ji.TransactionTypeID = 1; //Accounts Receivable
                    ji.ReversalID = tt.TransactionTypeID;
                    ji.DriverID = di.DriverID;
                    ji.Credit = ARCredit;
                    ji.Debit = ARDebit;
                    ji.Description = tt.TransactionType; //+ " - CH";
                    ji.CreatedBy = ConfigurationManager.AppSettings["Cashier"];
                    if (ds.GetJournalAccountID(tt.TransactionTypeID, LocationID) > 0)
                        ji.JournalID2 = ds.GetJournalAccountID(tt.TransactionTypeID, LocationID);
                    else //can we debit the suspense account or is a debit account always required?
                        ji.JournalID2 = ds.GetJournalAccountID(4, LocationID);

                    ds.AddJournalEntry(ji);

                    _logger.Debug("Add journal entry successful after pay card load: " + di.DriverNumber);

                }
                catch (Exception ex)
                {
                    _logger.Error("Exception in clearing the driver balance : " + di.DriverNumber);
                    _logger.Error("Exception in details are : " + ex.Message);
                }
            }
            else
            {

                //lblErrorMessage.Text += "Pay Card not loaded successfully : \n";
                //lblErrorMessage.Text += loadCardResponse.errorDetails[0].errorDescription;
                return;
            }
        }

        public void ChargeDriver(decimal amount, DriverInfo di)
        {

            DriverPayUnload driverPayCard = new DriverPayUnload();
            driverPayCard.businessPartnerId = ConfigurationManager.AppSettings["BusinessPartnerId"];
            driverPayCard.channelType = ConfigurationManager.AppSettings["ChannelType"];
            driverPayCard.currencyCode = ConfigurationManager.AppSettings["CurrencyCode"];
            driverPayCard.sourceTxnId = Convert.ToString(rnd.Next());
            double deductAmount = Convert.ToDouble(Math.Abs(decimal.Round(amount, 2))); // Convert.ToDouble(lblEndingBalance.Text.Trim().Replace("$", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty));
            driverPayCard.transactionAmount = (deductAmount * 100).ToString("#.##");
            driverPayCard.sourceName = ConfigurationManager.AppSettings["SourceName"];
            driverPayCard.sourceTxnDateTime = DateTime.Now.ToString("yyyy-MM-dd");
            driverPayCard.comments = "Card Unload";

            var reqCard = new DriverPayAPI();
            _logger.Debug("Calling Driver Pay card unload API");
            DriverPayUnloadResponse unloadCardResponse = null;
            try
            {
                unloadCardResponse = reqCard.UnloadCard(driverPayCard, di);

            }
            catch (Exception ex)
            {
                _logger.Error("Exception in unloading driver pay card : " + di.DriverNumber);
                _logger.Error("Exception in details are : " + ex.Message);
            }

            if (unloadCardResponse != null)
            {
                if (unloadCardResponse.errorDetails[0].errorCode == "120016")
                {
                    int balanceAmount = reqCard.BalanceEnquiry(di.CardUserID, di.CardProxyNumber);
                    if (balanceAmount != 0)
                    {
                        driverPayCard.transactionAmount = Convert.ToString(balanceAmount);
                        driverPayCard.sourceTxnId = Convert.ToString(rnd.Next());
                        unloadCardResponse = reqCard.UnloadCard(driverPayCard, di);
                    }
                }

                if (unloadCardResponse.errorDetails[0].errorCode == "0")
                {
                    decimal deductedAmount = Convert.ToDecimal(driverPayCard.transactionAmount) / 100;

                    try
                    {
                        //Add notes for Driver
                        string notes = String.Format("{0}{1}{2}", "Pay Card Unloaded Successfully for $(", deductedAmount, ")");
                        NoteItem ni = new NoteItem() { Note = notes };

                        ni.RelatedID = di.DriverID;
                        ni.NoteTypeID = 1;
                        ni.CreatedBy = ConfigurationManager.AppSettings["Cashier"];
                        ds.ModifyNotes(ni);
                        _logger.Debug("Added driver notes for pay card unload");

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Exception in updating driver notes : " + di.DriverNumber);
                        _logger.Error("Exception in details are : " + ex.Message);
                    }

                    try
                    {
                        //Since Add Payments will have CASH option as default (Inspite of driver payment type as CARD)
                        //string endingBalance = Convert.ToString(amount);
                        //int PaymentTypeID = Convert.ToInt32(cboPaymentType.SelectedItem.Value);

                        decimal ARCredit = deductedAmount; //Journal.StringToDecimal(endingBalance);
                        const decimal ARDebit = 0;

                        if (ARCredit <= 0)
                        {
                            //lblErrorMessage.Text = "The payment amount entered is not valid!";
                            return;
                        }

                        //create AR Journal entry
                        JournalItem ji = new JournalItem();
                        TransactionTypeItem tt = ds.GetTransactionTypeItemByName("Charge the Driver Card");
                        int LocationID = 1;

                        ji.LocationID = LocationID;
                        ji.JournalID = ds.GetJournalAccountID(1, LocationID);
                        ji.TransactionTypeID = 1; //Accounts Receivable
                        ji.ReversalID = tt.TransactionTypeID; //29
                        ji.DriverID = di.DriverID;
                        ji.Credit = ARCredit;
                        ji.Debit = ARDebit;
                        ji.Description = tt.TransactionType;
                        //ji.PaymentTypeID = di.PaymentTypeID;//Convert.ToInt32(cboPaymentType.Items.FindByText("Card").Value);
                        //ji.PaymentNumber = Server.HtmlEncode(txtReference.Text);
                        ji.CreatedBy = ConfigurationManager.AppSettings["Cashier"];

                        //now create the other Journal Entry
                        ji.JournalID2 = ds.GetJournalAccountID(tt.TransactionTypeID, LocationID);
                        ds.AddJournalEntry(ji);


                        _logger.Debug("Add journal entry successful after pay card unload:" + di.DriverNumber);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Exception in adding payments after unloading the pay card : " + di.DriverNumber);
                        _logger.Error("Exception in details are : " + ex.Message);
                    }
                }
                else {

                    _logger.Error("Exception in pay unaload : " + di.DriverNumber);
                    _logger.Error("Exception in details are : " + unloadCardResponse.errorDetails[0].errorDescription);
                }
            }
            else {
                _logger.Error("Pay Card unload failed due to a technical issue");
            }
        }
    }
}
