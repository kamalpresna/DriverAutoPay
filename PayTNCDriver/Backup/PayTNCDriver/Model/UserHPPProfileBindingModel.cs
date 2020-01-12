using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class UserHPPProfileBindingModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HPPProfileId { get; set; }
        public string FriendlyName { get; set; }
        public bool? PrimaryProfile { get; set; }

        //OrbitModel
        public string CustomerRefNumber { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string ECPAccountType { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
    }
}
