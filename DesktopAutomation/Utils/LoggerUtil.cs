using NLog;
using NUnit.Framework;

namespace DesktopAutomation.Core.Utils
{
    public static class LoggerUtil
    {
        private const string ConfigPath = @"Resources\NLog.config";
        private const string FolderPath = @"Resources\Logs";
        private static string TestName => TestContext.CurrentContext.Test.MethodName;
        private static string FormatDate => DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
        private static string FileName;
        private static Logger _logger;

        private static Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(ConfigPath);
                    LogManager.Configuration.Variables[nameof(FolderPath)] = FolderPath;
                    LogManager.Configuration.Variables[nameof(TestName)] = TestName;
                    LogManager.Configuration.Variables[nameof(FormatDate)] = FormatDate;
                    FileName = $"Log_{LogManager.Configuration.Variables[nameof(TestName)]}_{LogManager.Configuration.Variables[nameof(FormatDate)]}.log";

                    _logger = LogManager.GetLogger(TestName);
                }

                return _logger;
            }
        }

        public static string PathToLogFile => @$"{FolderPath}\{FileName}";

        public static void QuitLogger()
        {
            LogManager.Shutdown();
            _logger = null;
        }

        public static void Debug(string message) => Logger.Debug(message);

        public static void Warn(string message) => Logger.Warn(message);

        public static void Error(string message) => Logger.Error(message);

        public static void Fatal(string message) => Logger.Fatal(message);

        public static void Info(string message) => Logger.Info(message);
    }
}
