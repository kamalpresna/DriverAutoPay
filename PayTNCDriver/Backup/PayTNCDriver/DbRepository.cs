using System.Configuration;

namespace PayTNCDriver
{
    public class DbRepository
    {
        protected static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}
