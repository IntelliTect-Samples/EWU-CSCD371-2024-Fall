using Xunit;

namespace Logger.Tests;

public class LogFactoryTests : FileLoggerTestsBase
{
    [Fact]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }
}
