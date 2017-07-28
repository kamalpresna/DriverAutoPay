using System.Collections.Generic;

namespace PayTNCDriver.Model
{
    public class DriverPayBalance
    {
        public long localeTime { get; set; }
        public List<ErrorDetail> errorDetails { get; set; }
        public string proxy { get; set; }
        public int avlBal { get; set; }
        public string currency { get; set; }
        public int accountBal { get; set; }
    }
}
