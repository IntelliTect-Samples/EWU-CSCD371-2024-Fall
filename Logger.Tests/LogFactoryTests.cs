using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void FilePath_Configured_ReturnsNotNull()
    {
        // Arrange
        var factory = new LogFactory();
        
        // Act
        factory.ConfigureFileLogger("testFilePath");
        var testLogger = factory.CreateLogger("TestLogger");

        // Assert
        Assert.IsNotNull(testLogger);
    }

    [TestMethod]
    public void FilePath_NotConfigured_ReturnsNull()
    {
        // Arrange
        var factory = new LogFactory();

        // Act
        //factory.ConfigureFileLogger("testFilePath");
        var testLogger = factory.CreateLogger("null");

        // Assert
        Assert.IsNull(testLogger);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FilePath_PassedNull_ArgumentNullException()
    {
        var factory = new LogFactory();
        factory.ConfigureFileLogger(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FilePath_PassedEmpty_ArgumentException()
    {
        var factory = new LogFactory();
        factory.ConfigureFileLogger("");
    }

    [TestMethod]
    public void NameOf_Test()
    {
        var className = "FileLogger";

        Assert.AreEqual("className", nameof(className));
    }
}
