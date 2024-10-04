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
        TestLogger logger = new();
        logger.ClassName = className;
        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }
}
