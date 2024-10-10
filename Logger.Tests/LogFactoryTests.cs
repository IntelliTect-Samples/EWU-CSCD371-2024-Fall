using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void ConfigureFilePath_CreateValidFactory_Success()
    {
        // Arrange
        LogFactory factory = new();
        // Act
        var result = factory.ConfigureFilePath("test.txt");
        // Assert
        Assert.AreEqual("test.txt", result);
    }

    [TestMethod]
    public void CreateLogger_CreateValidLogger_Success()
    {
        // Arrange
        LogFactory factory = new();
        factory.ConfigureFilePath("test.txt");
        // Act
        var logger = factory.CreateLogger(nameof(LogFactoryTests));
        // Assert
        Assert.AreEqual(nameof(LogFactoryTests), logger?.ClassName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ConfigureFilePath_NullFilePath_ThrowsException()
    {
        // Arrange
        LogFactory factory = new();
        // Act
        factory.ConfigureFilePath(null!);
        // Assert
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateLogger_NullLoggerClassName_ThrowsException()
    {
        // Arrange
        LogFactory factory = new();
        factory.CreateLogger(nameof(LogFactoryTests));
        // Act
        var logger = factory.CreateLogger(null!);
        // Assert
    }


}
