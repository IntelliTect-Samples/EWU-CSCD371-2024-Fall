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
        //string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        _expectedFilePath = Path.Combine(LogFactory.GetSolutionDirectory() ?? "", "file.txt");

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
        var fileName = "file.txt"; // The file name provided
        //string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var expectedFilePath = LogFactory.GetSolutionDirectory() != null 
            ? Path.Combine(LogFactory.GetSolutionDirectory() ?? String.Empty, fileName) 
            : fileName; 

        // Act
        logFactory.ConfigureFileLogger(Path.Combine(LogFactory.GetSolutionDirectory() ?? String.Empty, fileName));

        // Try to access FilePath either as a field or a property
        var filePathField = typeof(LogFactory).GetField("FilePath", BindingFlags.NonPublic | BindingFlags.Instance);
        var filePathProperty = typeof(LogFactory).GetProperty("FilePath", BindingFlags.NonPublic | BindingFlags.Instance);

        // Check if we can find FilePath as either a field or a property
        Assert.IsTrue(filePathField != null || filePathProperty != null, "Could not find the private 'FilePath' field or property via reflection.");

        // Get the value from the field or property
        string? filePathValue = filePathField != null 
            ? filePathField.GetValue(logFactory) as string 
            : filePathProperty?.GetValue(logFactory) as string;

        // Assert that the FilePath is not null and matches the expected path
        Assert.IsNotNull(filePathValue, "FilePath was not set by the ConfigureFileLogger method.");
        Assert.AreEqual(expectedFilePath, filePathValue, $"FilePath does not match the expected value. Expected: {expectedFilePath}, Actual: {filePathValue}");
    }





    [TestMethod]
    public void CreateLogger_ShouldReturnFileLoggerWhenConfigured()
    {
        // Arrange
        var logFactory = new LogFactory();
        logFactory.ConfigureFileLogger("file.txt"); // Provide a valid file path

        // Act
        var logger = logFactory.CreateLogger("Test Class");

        // Assert
        Assert.IsNotNull(logger);
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
    }


    [TestMethod]
    public void CreateLogger_ShouldUseHardcodedFilePath()
    {
        // Arrange
        var logFactory = new LogFactory();
        var expectedFilePath = "file.txt"; // Provide the expected file path
        logFactory.ConfigureFileLogger(expectedFilePath);

        // Clean up any existing file
        if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }

        // Act
        var logger = logFactory.CreateLogger("Test Class");
        logger!.Log(LogLevel.Debug, "Test message");

        // Assert
        Assert.IsTrue(File.Exists(expectedFilePath), "Log file was not created.");
        var logContent = File.ReadAllText(expectedFilePath);
        Assert.IsTrue(logContent.Contains("Test message"), "Log file does not contain the expected log message.");
    }


    [TestCleanup]
    public void Cleanup()
    {
        // Clean up the log file after each test
        if (File.Exists(_expectedFilePath))
        {
            File.Delete(_expectedFilePath);
        }
    }
}

}