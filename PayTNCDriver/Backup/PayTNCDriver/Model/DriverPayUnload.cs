using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class DriverPayUnload
    {
        public string sourceTxnId { get; set; }
        public string channelType { get; set; }
        public string sourceTxnDateTime { get; set; }
        public string sourceName { get; set; }
        public string transactionAmount { get; set; }
        public string currencyCode { get; set; }
        public string businessPartnerId { get; set; }
        public string comments { get; set; }
    }

    public class DriverPayUnloadResponse
    {
        public List<ErrorDetail> errorDetails { get; set; }
        public int transactionId { get; set; }
        public object refNumber { get; set; }
        public object status { get; set; }
        public object feeDetail { get; set; }
        public object accountBalanceDetails { get; set; }
        public object seamlessEnabled { get; set; }
        public object userId { get; set; }
        public object track2 { get; set; }
        public int expiryDate { get; set; }
        public bool swiped { get; set; }
        public object proxy { get; set; }
        public object pan { get; set; }
        public object msisdn { get; set; }
    }
}
