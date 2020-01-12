using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Model
{
    public class APIAuthentication
    {
        public AdminAndUserLoginRequest adminAndUserLoginRequest { get; set; }
        public string token { get; set; }
        public int userId { get; set; }
    }
    public class Credentials
    {
        public object userName { get; set; }
        public object password { get; set; }
        public object agentId { get; set; }
        public object agentName { get; set; }
    }

    public class AdminAndUserLoginRequest
    {
        public object refId { get; set; }
        public Credentials credentials { get; set; }
        public object localeTime { get; set; }
        public int channelType { get; set; }
        public string program { get; set; }
        public int programId { get; set; }
        public string developerId { get; set; }
        public string developerPassword { get; set; }
        public object username { get; set; }
        public object password { get; set; }
        public object emailID { get; set; }
        public object mobileNumber { get; set; }
        public object userId { get; set; }
        public object cardNumber { get; set; }
        public object cvv { get; set; }
        public object expiryDate { get; set; }
        public object otp { get; set; }
        public object dateOfBirth { get; set; }
        public object proxy { get; set; }
        public object android_imei { get; set; }
        public object mpin { get; set; }
        public object mobileAppId { get; set; }
        public object loginName { get; set; }
        public object primaryLoginPassword { get; set; }
        public object secondaryLoginPassword { get; set; }
        public object loginUserIdType { get; set; }
        public object primaryLoginPasswordType { get; set; }
        public object secondaryLoginPasswordType { get; set; }
        public object idType { get; set; }
        public object idNumber { get; set; }
        public object userType { get; set; }
        public object requestorId { get; set; }
    }
}
