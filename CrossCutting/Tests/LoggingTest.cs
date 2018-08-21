using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Logging;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class LoggingTest
    {
        public LoggingTest()
        {
            Logger = DependencyInjector.GetService<ILogger>();
        }

        private ILogger Logger { get; }

        [TestMethod]
        public void LoggerError()
        {
            Logger.Error(new Exception(nameof(Logger.Error)));
        }
    }
}
