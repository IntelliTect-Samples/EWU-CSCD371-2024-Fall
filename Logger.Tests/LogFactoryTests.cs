using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void LogFactory_CreateLogger_ReturnsNull()
    {
        // Arrange
        var factory = new LogFactory();
        
        // Act
        factory.ConfigureFileLogger("testFilePath");
        var testLogger = factory.CreateLogger("TestLogger");

        // Assert
        Assert.IsNotNull(testLogger);
    }
}
