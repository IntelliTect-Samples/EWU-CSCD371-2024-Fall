using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LoggerFactoryTests
{
    [TestMethod]
    public void CreateLogger_WhenFilePathIsNull_ReturnsNull()
    {
        // Arrange
        FileLoggerFactory factory = new();
        //we don't configure the logger, so FilePath remains null.

        // Act
        FileLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));

        // Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("./")]
    [DataRow("/C:/Users/test/Documents")]
    [DataRow(null)]

    public void ConfigureFileLogger_GivenString_StoresValue(string? path)
    {
        //arrange
        FileLoggerFactory factory = new();
        //act
        factory.ConfigureFileLogger(path);
        //assert
        Assert.AreEqual(factory.FilePath, path);
    }

    [TestMethod]
    public void CreateLogger_FileLoggerClass_ReturnsValidLogger()
    {

        //Arrange
        FileLoggerFactory factory = new();
        factory.ConfigureFileLogger(Environment.ProcessPath) ;
        //Act

        FileLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_ConsoleLoggerClass_ReturnsValidLogger()
    {
        //Arrange
        ConsoleLoggerFactory factory = new();
        //Act
        ConsoleLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }

    [TestMethod]
    public void CreateLogger_TestLoggerClass_ReturnsValidLogger()
    {
        //Arrange
        TestLoggerFactory factory = new();
        //Act
        TestLogger? logger = factory.CreateLogger(nameof(LoggerFactoryTests));
        //Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(nameof(LoggerFactoryTests), logger!.ClassName);
    }


}