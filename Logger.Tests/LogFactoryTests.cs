using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace Logger.Tests
{
    [TestClass]
public class LogFactoryTests
{
    private string _expectedFilePath = string.Empty;

    [TestInitialize]
    public void Setup()
    {
        // Set up the expected log file path based on the hardcoded file name "file.txt"
        string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        _expectedFilePath = Path.Combine(assemblyLocation, "file.txt");

        // Ensure the log file is clean before each test
        if (File.Exists(_expectedFilePath))
        {
            File.Delete(_expectedFilePath);
        }
    }

    [TestMethod]
    public void ConfigureFileLogger_ShouldSetFilePath()
    {
        // Arrange
        var logFactory = new LogFactory();

        // Act
        logFactory.ConfigureFileLogger();

        // Use reflection to check if the private FilePath is set
        var filePathField = typeof(LogFactory).GetProperty("FilePath", BindingFlags.NonPublic | BindingFlags.Instance);
        var filePathValue = filePathField?.GetValue(logFactory) as string;

        // Assert
        Assert.IsNotNull(filePathValue);
        Assert.AreEqual(_expectedFilePath, filePathValue);  // _expectedFilePath now matches the hardcoded "file.txt"
    }

    [TestMethod]
    public void CreateLogger_ShouldReturnFileLoggerWhenConfigured()
    {
        // Arrange
        var logFactory = new LogFactory();
        logFactory.ConfigureFileLogger();  // Configure the file logger with a valid file path

        // Act
        var logger = logFactory.CreateLogger("TestClassName");

        // Assert
        Assert.IsNotNull(logger, "Logger should not be null");
        Assert.IsInstanceOfType(logger, typeof(FileLogger));  // Ensure it's of type FileLogger
    }

    [TestMethod]
    public void CreateLogger_ShouldUseHardcodedFilePath()
    {
        // Arrange
        var logFactory = new LogFactory();
        logFactory.ConfigureFileLogger();  // Configure with a hardcoded file path

        // Act
        var logger = logFactory.CreateLogger("TestClassName");
        Assert.IsNotNull(logger, "Logger should not be null");

        // Log message if logger is not null
        if (logger != null)
        {
            logger.Log(LogLevel.Debug, "Test message");
        }

        // Assert
        string hardcodedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");
        Assert.IsTrue(File.Exists(hardcodedFilePath), $"File '{hardcodedFilePath}' should exist");
        var logContent = File.ReadAllText(hardcodedFilePath);
        Assert.IsTrue(logContent.Contains("Test message"), "Log content should contain the test message");
    }
    
}

}
