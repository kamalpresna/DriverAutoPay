using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class DriverInfo
    {
        public int TransactionId { get; set; }
        public int DriverID { get; set; }
        public int DriverNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CardProxyNumber { get; set; }
        public int? CardUserID { get; set; }
        public decimal CardBalance { get; set; }
        public int LocationID { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Type { get; set; }

    }
}
