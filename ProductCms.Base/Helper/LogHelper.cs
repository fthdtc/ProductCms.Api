using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Base.Helper
{
    //improvement : use ELK for logging dashboard.
    public class LogHelper
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LogHelper));

        public static void Debug(string message)
        {
            _log4net.Debug(message);
        }

        public static void Error(string message)
        {
            _log4net.Error(message);
        }

        public static void Exception(Exception ex, string message)
        {
            //todo: parse exception object here.
            string exceptionLog = string.Format("Message:{0}\n StackTrace:{1} \n InnerException:{2}", message, ex.StackTrace, ex.InnerException);
            _log4net.Error(exceptionLog);
        }

        public static void Info(string message)
        {
            _log4net.Info(message);
        }

        public static void Trace(string message)
        {
            _log4net.Debug(string.Format("Trace:{0}:", message));
        }

        public static void Warning(string message)
        {
            _log4net.Warn(message);
        }
    }
}
