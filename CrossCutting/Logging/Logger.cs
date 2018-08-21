using System;
using System.IO;
using Serilog;
using Serilog.Formatting.Json;

namespace Solution.CrossCutting.Logging
{
    public class Logger : ILogger
    {
        private Serilog.ILogger Log { get; } = new LoggerConfiguration().WriteTo.File(new JsonFormatter(), Path.Combine("Logs", ".log"), rollingInterval: RollingInterval.Day).CreateLogger();

        public void Error(Exception exception)
        {
            Log.Error(exception, exception.Message);
        }
    }
}
