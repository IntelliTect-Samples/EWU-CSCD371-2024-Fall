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
        var expectedFilePath = "file.txt"; // Provide the expected file path

        // Act
        logFactory.ConfigureFileLogger(expectedFilePath);

        // Use reflection to check if the private FilePath field is set
        var filePathField = typeof(LogFactory).GetField("FilePath", BindingFlags.NonPublic | BindingFlags.Instance);
        var filePathValue = filePathField?.GetValue(logFactory) as string;

        // Assert
        Assert.IsNotNull(filePathValue);
        Assert.AreEqual(expectedFilePath, filePathValue);
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