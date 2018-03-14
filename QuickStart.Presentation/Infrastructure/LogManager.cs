using log4net;
using System;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace QuickStart.Presentation.Infrastructure
{
    public class LogManager
    {
        public static ILog log;

        public static void Initialize()
        {
            if (log != null) return;

            string logFileDirectory = string.Format("{0}\\Logs", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!Directory.Exists(logFileDirectory))
            {
                Directory.CreateDirectory(logFileDirectory);
            }
            log4net.Config.BasicConfigurator.Configure();
            log = log4net.LogManager.GetLogger(typeof(MvcApplication));
        }

        public static void LogInfo(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            log.Info(message);
        }

        public static void LogDebug(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            log.Debug(message);
        }

        public static void LogWarning(string message, Exception exception)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            log.Warn(message, exception);
        }

        public static void LogError(string message, Exception exception)
        {
            if (exception == null)
                return;

            try
            {
                log.Error(string.IsNullOrWhiteSpace(message) ? exception.Message : message, exception);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }

        public static void LogFatal(string message, Exception exception)
        {
            if (exception == null)
                return;

            try
            {
                log.Fatal(string.IsNullOrWhiteSpace(message) ? exception.Message : message, exception);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}