using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_Creation_Test_Successful()
    {
        //Arrange
        var logFactory = new LogFactory();
        logFactory.ConfigureFileLogger("Test");
        //Act
        var testLogger = logFactory.CreateLogger("Test");
        //Assert
        Assert.IsNotNull(testLogger, "Logger should not be null.");
        Assert.AreEqual("Test", testLogger?.ClassName);
    }
    [TestMethod]
    public void LogFactory_FilePathNotSet_ReturnsNull()
    {
        //Arrange
        var logFactory = new LogFactory();
        //Act
        var testLogger = logFactory.CreateLogger("");
        //Assert
        Assert.IsNull(testLogger);
    }
    [TestMethod]
    public void ConfigureFileLogger_FilePathCorrect()
    {
        //Arrange
        var logFactory = new LogFactory();
        string logger = logFactory.ConfigureFileLogger(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
       
        string expectedFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "Debuglog.txt";
        //Act
        
        //Assert
        Assert.AreEqual(expectedFilePath, logger);
        
    }

}
