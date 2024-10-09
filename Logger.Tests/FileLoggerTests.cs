using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CreatesLogFile_ChecksIfExists()
        {
            // Arrange
            string testFilePath = "testlog.txt";
            FileLogger logger = new FileLogger
            {
                FilePath = testFilePath,
            };

            // Act
            logger.Log(LogLevel.Error, "Test log entry");

            // Assert
            Assert.IsTrue(File.Exists(testFilePath)); // Check if file exists
        }


        // This test method
        [TestMethod]
        public void FileLogger_WritesCorrectMessageToFile()
        {
            // Arrange
            string testFilePath = "test.txt";
            FileLogger logger = new FileLogger
            {
                FilePath = testFilePath,
            };

            string message = "Test";

            // Act
            logger.Log(LogLevel.Error, message);

            // Assert
            string logContent = File.ReadAllText(testFilePath); // Read the file content
            Assert.IsTrue(logContent.Contains(message)); // Check if the message is in the file
            Assert.IsTrue(logContent.Contains("Error")); // Check if the log level is in the file
        }
    }
}



