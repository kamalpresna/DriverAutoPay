using System;


namespace PayTNCDriver.Model
{
    public class Driver
    {
        public int DriverID { get; set; }
        public int DriverNumber { get; set; }
        public string EmailAddress { get; set; }
        public int CardUserID { get; set; }
        public string CardProxyNumber { get; set; }
        public decimal CardBalance { get; set; }
        public int LocationID { get; set; }
        public int PaymentTypeID { get; set; }
    }
}
