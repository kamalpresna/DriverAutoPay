using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class PayPalTransaction
    {
        public int TransactionID;
        public int DriverID;
        public decimal Balance;
        public int TransactionTypeID;
        public string Response;
        public string ReferenceBatchID;
        public string ReferenceItemID;
        public string RecipientType;
        public string SenderBatchID;
        public string Errors;
        public int LocationID;
        public string CreatedBy;
        public decimal PartialPaidAmount;
    }
}
