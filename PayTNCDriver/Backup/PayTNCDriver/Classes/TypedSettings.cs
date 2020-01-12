using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTNCDriver.Classes
{
    public static class TypedSettings
    {
        public static bool IsDialRide => Convert.ToBoolean(ConfigurationManager.AppSettings["IsDialRide"]);

        public static bool PerformAchTransaction { get { bool.TryParse(ConfigurationManager.AppSettings["PerformAchTransaction"], out bool b); return b; } }
    }
}
