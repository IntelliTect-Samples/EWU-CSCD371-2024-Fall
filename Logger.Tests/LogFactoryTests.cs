using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private string _filePath = "";
    private FileLogger _logger = null!;
    private string _newPath = "";

    [TestInitialize]
    public void TestInitialize()
    {
        _filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt";
        _logger = new FileLogger(_filePath, "Test");
    }

    [TestMethod]
    public void CreateLogger_ValidFilePath_ReturnsFileLogger()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        // Act
        facLog.ConfigureFileLogger("log.txt");
        // Assert
        Assert.IsInstanceOfType(facLog.CreateLogger("Test"), typeof(FileLogger));
    }

    [TestMethod]
    public void CreateLogger_NullFilePath_ReturnsNull()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        // Act
        // Assert
        Assert.IsNull(facLog.CreateLogger("Test"));
    }

    [TestMethod]
    public void ConfigureFileLogger_NewFilePath_ReturnsFileLoggerWithCorrectPath()
    {
        // Arrange
        LogFactory facLog = new LogFactory();
        _newPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logNew.txt";
        // Act
        facLog.ConfigureFileLogger(_newPath);
        var newLogger = (FileLogger)facLog.CreateLogger("Test")!; //this need be done seperately to avoid null exception CS8600
        // Assert
        Assert.AreEqual(_newPath, newLogger.FilePath) ;
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
