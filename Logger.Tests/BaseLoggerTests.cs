namespace Logger.Tests;

internal class BaseLoggerTests
{
    public void ClassName_TestClass_Success()
    {
        //Arrange
        string className = "TestClass";
        //Act
        BaseLogger logger = new();
        logger.ClassName = className;
        //Assert
        Assert.AreEqual(className, logger.ClassName);
    }
}
