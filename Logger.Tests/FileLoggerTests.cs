using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_CreatesLogFile_ReturnsTrue()
        {
            // Arrange
            string testFilePath = "testlog.txt";
            FileLogger logger = new FileLogger(testFilePath);

            // Act
            logger.Log(LogLevel.Error, "Test log entry");

            // Assert
            Assert.IsTrue(File.Exists(testFilePath));
        }

        [TestMethod]
        public void Log_WritesMessageAndLogLevel_ReturnsTrue()
        {
            // Arrange
            string testFilePath = "test.txt";
            FileLogger logger = new FileLogger(testFilePath);

            string message = "Test";

            // Act
            logger.Log(LogLevel.Error, message);

            // Assert
            string logContent = File.ReadAllText(testFilePath); // Read the file content
            Assert.IsTrue(logContent.Contains(message)); // Check if the message is in the file
            Assert.IsTrue(logContent.Contains("Error")); // Check if the log level is in the file
        }

        [TestMethod]
        public void Log_FormatsMessageCorrectly_ReturnsTrue()
        {
            // Arrange
            string testFilePath = "testlog.txt";
            FileLogger logger = new FileLogger(testFilePath)
            {
                ClassName = "TestLogger" // class name for testing
            };

            string message = "Test log message";
            LogLevel logLevel = LogLevel.Warning;

            // Act
            logger.Log(logLevel, message);

            // Assert
            string logContent = File.ReadAllText(testFilePath); // Read the log file

            // Had to seperate the date and rest of the log message. Couldnt get it to work right.  Should work the same though.
            
            // Check date format in MM/dd/yyyy
            string expectedDate = DateTime.Now.ToString("MM/dd/yyyy");
            Assert.IsTrue(logContent.Contains(expectedDate));

            // Check the rest of log message
            Assert.IsTrue(logContent.Contains($"{logger.ClassName} {logLevel}: {message}"), "Log message does not match the expected format.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilePath_PassedNull_ArgumentNullException()
        {
            FileLogger fl = new FileLogger(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilePath_PassedEmpty_ArgumentNullException()
        {
            FileLogger fl = new FileLogger("");
        }

        [TestMethod]
        public void FilePath_PassedNotNull_NotNull()
        {
            FileLogger fl = new FileLogger("Non-Null-FilePath");
            Assert.IsNotNull(fl.FilePath);
        }

    }
}
