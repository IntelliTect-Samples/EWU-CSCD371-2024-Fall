using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    protected string _filePath;
    protected FileLogger _logger;

    protected string _newPath;

    [TestInitialize]
    public void TestInitialize()
    {
        _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
        _logger = new FileLogger(_filePath, "Test");
    }

    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsFileLogger()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        // Act
        facLog.ConfigureFileLogger("log.txt");
        // Assert
        Assert.IsInstanceOfType(facLog.CreateLogger("Test"), typeof(FileLogger));
    }

    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsNull()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        // Act
        facLog.ConfigureFileLogger(null);
        // Assert
        Assert.IsNull(facLog.CreateLogger("Test"));
    }

    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsFileLoggerWithCorrectPath()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        // Act
        _newPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logNew.txt";
        facLog.ConfigureFileLogger(_newPath);
        // Assert
        Assert.AreEqual(_newPath, ((FileLogger)facLog.CreateLogger("Test")).FilePath);
    }


    [TestCleanup]
    public void TestCleanup()
    {
        if(File.Exists(_filePath) | File.Exists(_newPath))
        {
            File.Delete(_newPath);
            File.Delete(_filePath);
        }
    }


}
