using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private readonly string _fileName = "test.txt";

    [TestMethod]
    public void FileLogger_CreateValidFile_Success()
    {
        // Arrange
        FileLogger logger = new(_fileName);
        // Act
        // Assert
        Assert.IsNotNull(logger);
    }

    [TestMethod]
    public void Log_LogFileAppended_Success()
    {
        // Arrange
        string message = "Testing123";
        FileLogger logger = new(_fileName);
        logger.ClassName = nameof(FileLoggerTests);
        // Act
        logger.Log(LogLevel.Debug, message);
        string results = File.ReadAllText(_fileName);
        // Assert
        Assert.IsTrue(results.Contains(message));
    }

    [TestCleanup]
    public void CleanUp()
    {
        if(File.Exists(_fileName))
            File.Delete(_fileName);
    }

}
