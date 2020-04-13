using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace JnjStudyCompoundChecker.Helper
{
    public class LogHelper
    {
        public static List<string> ErrorMessage = new List<string>
        {
            "error", "exception", "fail", "failed", "interrupted"
        };

        public string InstanceId { get; set; }
        private static LogHelper _instance;
        private static readonly object SyncLock = new object();
        public ILogger Logger;

        private LogHelper()
        {
            // Config Serilog
            var logPath = Program.Configuration.GetSection("LogFilePath").Value;
            Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

        }

        public static void Reset()
        {
            lock (SyncLock)
            {
                _instance = null;
            }
        }

        public static LogHelper Instance
        {
            get
            {
                lock (SyncLock) { return _instance ?? (_instance = new LogHelper()); }
            }
            set
            {
                lock (SyncLock) { _instance = value; }
            }
        }

        public static void PrintLog(string msg)
        {
            Log.Logger = Instance.Logger;
            var isErrorMsg = ErrorMessage.Any(msg.ToLower().Contains);
            if (isErrorMsg) Log.Error(msg);
            else Log.Information(msg);
        }
    }
}
