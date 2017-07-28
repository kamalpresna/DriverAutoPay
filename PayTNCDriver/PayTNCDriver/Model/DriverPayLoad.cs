using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class DriverPayLoad
    {
        public string sourceTxnId { get; set; }
        public string channelType { get; set; }
        public string refId { get; set; }
        public string agentId { get; set; }
        public string sourceTxnDateTime { get; set; }
        public string sourceName { get; set; }
        public string transactionAmount { get; set; }
        public string currencyCode { get; set; }
        public string comments { get; set; }
    }

    public class DriverPayLoadResponse
    {
        public string refId { get; set; }
        public long localeTime { get; set; }
        public List<ErrorDetail> errorDetails { get; set; }
        public int transactionId { get; set; }
        public string refNumber { get; set; }
        public List<AccountBalanceDetail> accountBalanceDetails { get; set; }
        public string proxy { get; set; }

    }

    public class ErrorDetail
    {
        public string errorCode { get; set; }
        public string errorDescription { get; set; }
    }

    public class AccountBalanceDetail
    {
        public int txnAccountId { get; set; }
        public int availableBalance { get; set; }
        public int accountBalance { get; set; }
        public string isoCurrencyCode { get; set; }
    }
}
