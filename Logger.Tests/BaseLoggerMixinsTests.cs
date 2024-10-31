using System;
using System.Collections.Generic;
using Xunit;

namespace Logger.Tests;

public class BaseLoggerMixinsTests
{
    [Fact]
    public void ErrorWithNullLoggerThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            BaseLoggerMixins.Error(null!, ""));
    }

    [Fact]
    public void ErrorWithDataLogsMessage()
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

}
