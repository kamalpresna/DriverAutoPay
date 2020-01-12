using System;
using System.Reflection;
using log4net;


namespace PayTNCDriver
{
    public class LogHandler
    {
        private static volatile LogHandler _logHandler = null;
        private static object myLock = new object();

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LogHandler()
        {
            // Initialize log4net.
            log4net.Config.XmlConfigurator.Configure();
        }

        public ILog GetLogger()
        {
            return _logger;
        }

        public static LogHandler GetInstance()
        {
            if (_logHandler == null)
            {
                lock (myLock)
                {
                    if (_logHandler == null)
                    {
                        _logHandler = new LogHandler();
                    }
                }
            }

            return _logHandler;

        }
    }
}
