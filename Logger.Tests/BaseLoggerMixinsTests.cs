using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests;

public class BaseLoggerMixinsTests
{
    [Fact]
    public void Error_WithNullLogger_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            BaseLoggerMixins.Error(null!, ""));
    }

    [Fact]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Error("Message 42");

        // Assert
        Assert.Single(logger.LoggedMessages);
        Assert.Equal(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.Equal("Message 42", logger.LoggedMessages[0].Message);
    }

    [Fact]
    public void Warning_WithNullLogger_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            BaseLoggerMixins.Warning(null!, ""));
    }
    [Fact]
    public void Warning_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Warning("Message WithData");

        // Assert
        Assert.Single(logger.LoggedMessages);
        Assert.Equal(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.Equal("Message WithData", logger.LoggedMessages[0].Message);

    }
    [Fact]
    public void Information_WithNullLogger_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            BaseLoggerMixins.Information(null!, ""));
    }
    [Fact]
    public void Information_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Information("Message WithData");

        // Assert
        Assert.Single(logger.LoggedMessages);
        Assert.Equal(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.Equal("Message WithData", logger.LoggedMessages[0].Message);

    }
    [Fact]
    public void Debug_WithNullLogger_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            BaseLoggerMixins.Debug(null!, ""));
    }
    [Fact]
    public void Debug_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Debug("Message WithData");

        // Assert
        Assert.Single(logger.LoggedMessages);
        Assert.Equal(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
        Assert.Equal("Message WithData", logger.LoggedMessages[0].Message);

    }
}
