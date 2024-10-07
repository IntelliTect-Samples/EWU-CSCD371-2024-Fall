using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void FileLogger_TestClassName_Success()
    {
        //Arrange
        string className = "TestClass";
        string filePath = "TestPath";

        //Act
        FileLogger logger = new(filePath);
        logger.ClassName = className;

        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }

    [TestMethod]
    public void FileLogger_Constructor_Success()
    {
        //Arrange
        string filePath = "TestPath";

        //Act
        FileLogger logger = new(filePath);

        //Assert
        Assert.IsNotNull(logger);
    }
}
