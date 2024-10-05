using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        private string _logFilePath = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            // Set up the log file path based on the assembly location
            string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            _logFilePath = Path.Combine(assemblyLocation, "testlog.txt");

            // Ensure the log file is clean before each test
            if (File.Exists(_logFilePath))
            {
                File.Delete(_logFilePath);
            }
        }

        [TestMethod]
        public void Log_ShouldWriteMessageToFile()
        {
            // Arrange
            var logger = new FileLogger(_logFilePath)
            {
                ClassName = nameof(FileLoggerTests)
            };

            string expectedMessage = "Test message";

            // Act
            logger.Log(LogLevel.Information, expectedMessage);

            // Assert
            string logContent = File.ReadAllText(_logFilePath);
            Assert.IsTrue(logContent.Contains(expectedMessage));
            Assert.IsTrue(logContent.Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(logContent.Contains("Information"));
        }

        [TestMethod]
        public void Log_ShouldIncludeTimestamp()
        {
            // Arrange
            var logger = new FileLogger(_logFilePath)
            {
                ClassName = nameof(FileLoggerTests)
            };

            string expectedMessage = "Another test message";

            // Act
            logger.Log(LogLevel.Warning, expectedMessage);

            // Assert
            string logContent = File.ReadAllText(_logFilePath);
            DateTime currentDateTime = DateTime.Now;

            // Check that the log file contains a date/time similar to the current date/time
            Assert.IsTrue(logContent.Contains(currentDateTime.ToString("M/d/yyyy", CultureInfo.InvariantCulture)));  // Use CultureInfo.InvariantCulture
        }


        [TestMethod]
        public void Log_FileShouldCreateIfNotExists()
        {
            // Arrange
            var logger = new FileLogger(_logFilePath)
            {
                ClassName = nameof(FileLoggerTests)
            };

            // Act
            logger.Log(LogLevel.Error, "Error test message");

            // Assert
            Assert.IsTrue(File.Exists(_logFilePath));
        }
        
    }
}
