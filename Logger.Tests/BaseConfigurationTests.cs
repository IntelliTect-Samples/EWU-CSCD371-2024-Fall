using Xunit;

namespace Logger.Tests;

public class BaseConfigurationTests
{
    [Fact]
    public void Constructor_ValidLogSource_SetsLogSource()
    {
        //Arrange
        BaseLoggerConfiguration baseLogger = new(nameof(BaseConfigurationTests));

        //Act

        //Assert
        Assert.NotNull(baseLogger);
        Assert.Equal(nameof(BaseConfigurationTests), baseLogger.LogSource);
    }

    [Theory]
    [InlineData (null)]
    [InlineData("")]
    public void Constructor_NullOrEmptyLogSource_ThrowsArgumentException(string? logSource)
    {
        //Arrange
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new BaseLoggerConfiguration(logSource!));
    }
}
