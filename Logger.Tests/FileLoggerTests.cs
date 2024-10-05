using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void ClassName_TestClass_Success()
    {
        //Arrange
        string className = "TestClass";

        //Act
        FileLogger logger = new();
        logger.ClassName = className;

        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }

    [TestMethod]
    public void FileLogger_TestInitializeFilePath_True()
    {
        //Arrange
        string filePath = "TestPath";

        //Act
        FileLogger logger = new();
        logger.FileLogger(filePath);

        //Assert
        Assert.AreEqual(filePath, logger.FileLogger);

    }
}
