using System;
using System.Collections.Generic;
using System.Configuration;
using CARS.Data.DataAccess;
using CARS.Data.Entity;
using CARS.Service;
using log4net;
using PayTNCDriver.Model;
using TotalRide.Payments;
using TotalRide.Payments.Contracts;
using TotalRide.Payments.Helpers;
using TotalRide.Payments.Models;
using System.Linq;

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
                    if (di.DriverID != null)
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
                else
                {

                    _logger.Error("Exception in pay unaload : " + di.DriverNumber);
                    _logger.Error("Exception in details are : " + unloadCardResponse.errorDetails[0].errorDescription);
                }
            }
            else
            {
                _logger.Error("Pay Card unload failed due to a technical issue");
            }
        }

        public void ProcessPayPalDrivers(IList<DriverInfo> payPalTransactionList)
        {
            var payoutList = payPalTransactionList.Where(x => x.CardBalance > 0).ToList();

            if (payoutList.Count > 0)
                PayPalPayment(payoutList);

            var invoiceList = payPalTransactionList.Where(x => x.CardBalance < 0).ToList();

            if(invoiceList.Count > 0)
                PayPalInvoice(invoiceList);
        }

        public void PayPalPayment(IList<DriverInfo> payPalTransactionList)
        {
            try
            {
                string notes = string.Empty;
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                int tday = (DateTime.Now - firstDay).Days;

                Random rnd = new Random();
                int rndNumber = rnd.Next(15000);
                string batch_id = DateTime.Now.Year.ToString() + "-" + tday.ToString() + "-" + rndNumber.ToString();

                //PayOuts
                Sender_batch_header sbh = new Sender_batch_header
                {
                    email_subject = ConfigurationManager.AppSettings["PayPalEmailSubject"],
                    sender_batch_id = batch_id
                };

                int itemNumber = 1;

                RequestHelper rh = new RequestHelper();
                //Get Auth
                string OAuthUrl = ConfigurationManager.AppSettings["PayPalOAuthUrl"];
                string userName = ConfigurationManager.AppSettings["PayPalUsername"];
                string skey = ConfigurationManager.AppSettings["PayPalPassword"];
                rh.SetCredentials(OAuthUrl, userName, skey);

                IPay payoutService = new PayPalService();

                List<Items> iList = new List<Items>();
                IDictionary<string, int> driverSenderItemID = new Dictionary<string, int>();
                IDictionary<string, int> driverLocationID = new Dictionary<string, int>();
                IDictionary<string, string> driverReceiver = new Dictionary<string, string>();

                foreach (var i in payPalTransactionList)
                {
                    var ppt = DataAccess.GetPayPalPendingPayoutTransaction(i.DriverID);
                    decimal transactionBalance = i.CardBalance;

                    //if exist a pending transaction, then we cancel 
                    //the previous and create a new transaction with the new balance.
                    if (ppt.DriverID > 0)
                    {
                        if (ppt.Balance != i.CardBalance)
                        {
                            DataAccess.UpdatePayPalTransaction(
                                          ppt.DriverID,
                                          ppt.Balance,
                                          "SENDING TO CANCEL",
                                          ppt.ReferenceBatchID,
                                          ppt.ReferenceItemID,
                                          string.Empty,
                                          0
                                          );

                            string url = ConfigurationManager.AppSettings["PayPalPayOutItemUrl"] + "/" + ppt.ReferenceItemID + "/cancel";
                            payoutService.CancelPayoutItem(ppt.ReferenceItemID, rh, url);

                            notes = String.Format("{0} {1} {2}", "PayPal Payout Sending To Cancel:", " $", Math.Round(ppt.Balance, 2));
                            NoteItem ni = new NoteItem { Note = notes };
                            if (ppt.DriverID != 0)
                                ni.RelatedID = ppt.DriverID;
                            ni.NoteTypeID = 1;
                            ni.CreatedBy = ppt.CreatedBy;   

                            var nt = new Notes();
                            nt.Modify(ni);

                            //Get the new transaction balance
                            transactionBalance = i.CardBalance;

                            Items item = new Items
                            {
                                recipient_type = i.CommType == 5 ? RecipientType.EMAIL : RecipientType.PHONE,
                                receiver = i.CommType == 5 ? i.EmailAddress : i.PhoneNumber,
                                note = "Payout Item Transaction for $" + Math.Round(transactionBalance, 2).ToString(),
                                sender_item_id = "item-" + itemNumber.ToString() + "-" + batch_id
                            };

                            Amount amount = new Amount();
                            amount.currency = ConfigurationManager.AppSettings["PayPalCurrency"];
                            amount.value = Math.Round(transactionBalance, 2);
                            item.amount = amount;

                            driverSenderItemID.Add(item.sender_item_id, i.DriverID);
                            driverLocationID.Add(item.sender_item_id, i.LocationID);
                            driverReceiver.Add(item.sender_item_id, item.receiver);

                            iList.Add(item);
                            itemNumber++;
                        }
                    }
                    else
                    {
                        Items item = new Items
                        {
                            recipient_type = i.CommType == 5 ? RecipientType.EMAIL : RecipientType.PHONE,
                            receiver = i.CommType == 5 ? i.EmailAddress : i.PhoneNumber,
                            note = "Payout Item Transaction for $" + Math.Round(transactionBalance, 2).ToString(),
                            sender_item_id = "item-" + itemNumber.ToString() + "-" + batch_id
                        };

                        Amount amount = new Amount();
                        amount.currency = ConfigurationManager.AppSettings["PayPalCurrency"];
                        amount.value = Math.Round(transactionBalance, 2);
                        item.amount = amount;

                        driverSenderItemID.Add(item.sender_item_id, i.DriverID);
                        driverLocationID.Add(item.sender_item_id, i.LocationID);
                        driverReceiver.Add(item.sender_item_id, item.receiver);

                        iList.Add(item);
                        itemNumber++;
                    }  
                }

                Items[] items = iList.ToArray();
                PaymentDataModel pdm = new PaymentDataModel
                {
                    sender_batch_header = sbh,
                    items = items
                };

                _logger.Debug("Calling PayPal Payout API");
                var responseObject = payoutService.ProcessPayment(pdm, rh);
                _logger.Debug("Calling PayPal GET Payout Details API");
                var PayoutDetails = payoutService.GetPayoutDetails(responseObject.batch_header.payout_batch_id, rh);

                string errorMessage = string.Empty;
                int driverId = 0;
                int locationId = 0;
                string receiver = string.Empty;

                foreach (var item in PayoutDetails.items)
                {
                    errorMessage = item.errors != null ? item.errors.name + "--" + item.errors.message : string.Empty;

                    if (driverSenderItemID.ContainsKey(item.payout_item.sender_item_id))
                        driverId = driverSenderItemID[item.payout_item.sender_item_id];

                    if (driverLocationID.ContainsKey(item.payout_item.sender_item_id))
                        locationId = driverLocationID[item.payout_item.sender_item_id];

                    if (driverReceiver.ContainsKey(item.payout_item.sender_item_id))
                        receiver = driverReceiver[item.payout_item.sender_item_id];

                    notes = String.Format("{0} {1} {2}", "Created PayPal Payment: " + receiver, " $", item.payout_item.amount.value);
                    NoteItem ni = new NoteItem { Note = notes };
                    if (driverId != 0)
                        ni.RelatedID = driverId;
                    ni.NoteTypeID = 1;
                    ni.CreatedBy = ConfigurationManager.AppSettings["Cashier"];
                    var nt = new Notes();
                    nt.Modify(ni);

                    TransactionTypeItem ti;
                    ti = ds.GetTransactionTypeItemByName("PayPal Settlement to Driver");

                    DataAccess.AddPayPalTransaction(driverId,
                        Convert.ToDecimal(item.payout_item.amount.value),
                        ti.TransactionTypeID,
                        item.transaction_status,
                        responseObject.batch_header.payout_batch_id,
                        item.payout_item_id,
                        item.payout_item.recipient_type,
                        PayoutDetails.batch_header.sender_batch_header.sender_batch_id,
                        errorMessage,
                        locationId,
                        ConfigurationManager.AppSettings["Cashier"]);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception in details are : " + ex.Message);
            }
        }

        public void PayPalInvoice(IList<DriverInfo> payPalTransactionList)
        {
            try
            {
                foreach (var i in payPalTransactionList)
                {
                    AddressListItem addressListItem = DataAccess.GetAddressListItemForContactID(i.ContactID);
                    ContactListItem cli = ds.GetContactListItem(i.ContactID);

                    if (addressListItem.AddressID == 0)
                    {
                        _logger.Error("The Driver #" + i.DriverNumber + " doesn't have an address defined.");
                        continue;
                    }

                    if (cli == null)
                    {
                        _logger.Error("The Driver #" + i.DriverNumber + " doesn't have a contact created.");
                        continue;
                    }

                    //Invoicing
                    Phone p = new Phone();
                    p.country_code = "001";
                    p.national_number = "6022005500";

                    string consolidated = string.IsNullOrEmpty(addressListItem.StreetNumber) ? addressListItem.StreetName : addressListItem.StreetNumber + " " + addressListItem.StreetName;

                    TotalRide.Payments.Models.Address addr = new TotalRide.Payments.Models.Address
                    {
                        line1 = "4600 W. Camelback Road",
                        city = "Glendale",
                        state = "AZ",
                        postal_code = "85301",
                        country_code = "US"
                    };

                    MerchantInfo minfo = new MerchantInfo
                    {
                        email = ConfigurationManager.AppSettings["PayPalTotalRideEmail"],
                        first_name = "Total Transit",
                        last_name = "Enterprises, LLC",
                        business_name = ConfigurationManager.AppSettings["PayPalInvcBusinessName"],
                        phone = p,
                        address = addr
                    };

                    BillingInfo bi = new BillingInfo
                    {
                        email = i.EmailAddress,
                        first_name = cli.FirstName,
                        last_name = cli.LastName
                    };

                    Address2 addr2 = new Address2
                    {
                        line1 = consolidated,
                        city = addressListItem.City,
                        state = addressListItem.State,
                        postal_code = addressListItem.ZipCode,
                        country_code = "US"
                    };

                    ShippingInfo si = new ShippingInfo
                    {
                        first_name = cli.FirstName,
                        last_name = cli.LastName,
                        address = addr2
                    };

                    UnitPrice up = new UnitPrice
                    {
                        currency = ConfigurationManager.AppSettings["PayPalCurrency"],
                        value = Math.Abs(Math.Round(i.CardBalance,2)).ToString()
                    };

                    //Tax tx = new Tax
                    //{
                    //    name = "Tax",
                    //    percent = 8
                    //};

                    InvcItem invcItem = new InvcItem
                    {
                        name = "Total Ride Driver Charge",
                        quantity = 1,
                        unit_price = up//,
                        //tax = tx
                    };

                    InvcAmount invcAmount = new InvcAmount
                    {
                        currency = ConfigurationManager.AppSettings["PayPalCurrency"],
                        value = "0" //Shipping Address Cost
                    };

                    ShippingCost sc = new ShippingCost
                    {
                        amount = invcAmount
                    };

                    List<BillingInfo> binfo = new List<BillingInfo>();
                    binfo.Add(bi);

                    List<InvcItem> ii = new List<InvcItem>();
                    ii.Add(invcItem);

                    InvoiceDataModel idm = new InvoiceDataModel
                    {
                        merchant_info = minfo,
                        billing_info = binfo,
                        shipping_info = si,
                        items = ii,
                        shipping_cost = sc,
                        note = ConfigurationManager.AppSettings["PayPalNote"],
                        terms = ConfigurationManager.AppSettings["PayPalInvcTerms"],
                        logo_url = ConfigurationManager.AppSettings["PayPalLogoURL"]
                    };

                    if (Math.Abs(i.CardBalance) > Convert.ToDecimal(ConfigurationManager.AppSettings["PayPalPartialMinimumAmountDue"]))
                    {
                        MinimumAmountDue minimum_amount_due = new MinimumAmountDue();
                        minimum_amount_due.currency = ConfigurationManager.AppSettings["PayPalCurrency"];
                        minimum_amount_due.value = ConfigurationManager.AppSettings["PayPalPartialMinimumAmountDue"];
                        idm.allow_partial_payment = true;
                        idm.minimum_amount_due = minimum_amount_due;
                    }

                    RequestHelper rh = new RequestHelper();
                    //Get Auth
                    string OAuthUrl = ConfigurationManager.AppSettings["PayPalOAuthUrl"];
                    string userName = ConfigurationManager.AppSettings["PayPalUsername"];
                    string skey = ConfigurationManager.AppSettings["PayPalPassword"];
                    rh.SetCredentials(OAuthUrl, userName, skey);

                    IPay payoutService = new PayPalService();
                    _logger.Debug("Calling PayPal Invoice API");
                    var responseInvcObject = payoutService.ProcessInvoice(idm, rh);

                    _logger.Debug("Calling PayPal GET Invoice Details API");
                    var invoiceDetails = payoutService.GetInvoiceDetails(responseInvcObject.id, rh);

                    string notes = String.Format("{0} {1} {2}", "Created PayPal Invoice: " + bi.email, " $", Math.Abs(i.CardBalance).ToString());
                    NoteItem ni = new NoteItem { Note = notes };
                    if (i.DriverID != 0)
                        ni.RelatedID = i.DriverID;
                    ni.NoteTypeID = 1;
                    ni.CreatedBy = ConfigurationManager.AppSettings["Cashier"];

                    var nt = new Notes();
                    nt.Modify(ni);

                    string errorMessage = string.Empty;

                    TransactionTypeItem ti;
                    ti = ds.GetTransactionTypeItemByName("PayPal Settlement from Driver");

                    DataAccess.AddPayPalTransaction(i.DriverID,
                        Math.Abs(i.CardBalance),
                        ti.TransactionTypeID,
                        invoiceDetails.status,
                        invoiceDetails.id,
                        invoiceDetails.number,
                        RecipientType.EMAIL,
                        invoiceDetails.invoice_date,
                        errorMessage,
                        i.LocationID,
                        ConfigurationManager.AppSettings["Cashier"]);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception in details are : " + ex.Message);
            }
        }
    }
}
