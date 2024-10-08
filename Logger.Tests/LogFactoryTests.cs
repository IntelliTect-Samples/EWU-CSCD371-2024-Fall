using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    /*
     * This test expects CreateLogger to return null when there isn't a file path configured for LogFactory
     * because I haven't implemented the ConfigureFileLogger method, resulting in the factory being unconfigured.
     */

    [TestMethod]
    public void CreateLogger_NoConfiguration_Null()
    {
        //Arrange
        LogFactory factory = new();

        //Act
        BaseLogger logger = factory.CreateLogger("TestClass");

        //Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void ConfigureFileLogger_Filepath_Success()
    {
        //Arrange
        LogFactory factory = new();
        string filePath = "TestPath";

        //Act
        factory.ConfigureFileLogger(filePath);

        //Assert
        Assert.AreEqual(filePath, factory.GetFilePath());

    }

    [TestMethod]
    public void CreateLogger_WithNullFilePath_Null()
    {
        //Arrange
        LogFactory factory = new();
        string testClass = "TestClass";
        factory.ConfigureFileLogger(null);

        //Act
        BaseLogger logger = factory.CreateLogger(testClass);

        //Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateLogger_WithConfiguration_FileLogger()
    {
        //Arrange
        LogFactory factory = new();
        string filePath = "TestPath";
        string testClass = "TestClass";
        factory.ConfigureFileLogger(filePath);

        //Act
        BaseLogger logger = factory.CreateLogger(testClass);

        //Assert
        Assert.IsInstanceOfType(logger, typeof(FileLogger));
        Assert.AreEqual(testClass, logger.ClassName);

    }
}
