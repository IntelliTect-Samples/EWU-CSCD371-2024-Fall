using System;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        private string _filePath = "";
        private FileLogger _logger = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
            _logger = new FileLogger(_filePath, "Test");
        }

        [TestMethod]
        public void Log_InfoMessage_AppendsToFileWithContent()
        {
            // Arrange
            var logLevel = LogLevel.Information;
            string message = "Text to test the log method.";

            // Act
            _logger.Log(logLevel, message);

            // Assert
            string logEntry = File.ReadAllText(_filePath);
            StringAssert.Contains(logEntry, message);
        }

        [TestMethod]
        public void Log_MultipleMessages_AppendsMessagesToFile()
        {
            // Arrange
            var firstMessage = "First message";
            var secondMessage = "Second message";

            // Act
            _logger.Log(LogLevel.Warning, firstMessage);
            _logger.Log(LogLevel.Warning, secondMessage);

            // Assert
            string[] logEntries = File.ReadAllLines(_filePath);
            Assert.AreEqual(2, logEntries.Length);
            StringAssert.Contains(logEntries[0], firstMessage);
            StringAssert.Contains(logEntries[1], secondMessage);
        }

        [TestMethod]
        public void Log_MessageWithTimestamp_AppendsTimestampToLogEntry()
        {
            // Arrange
            var message = "Time stamp message.";

            // Act
            _logger.Log(LogLevel.Information, message);

            // Assert
            string logEntry = File.ReadAllText(_filePath);
            DateTime parsedDateTime;
            bool containsTimestamp = DateTime.TryParse(logEntry.AsSpan(0, 22), out parsedDateTime);
            Assert.IsTrue(containsTimestamp, "Entry doesn't have correct timestamp.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}
