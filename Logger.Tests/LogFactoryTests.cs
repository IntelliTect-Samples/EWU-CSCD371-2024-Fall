using Xunit;

namespace Logger.Tests;

public class LogFactoryTests : FileLoggerTestsBase
{
    [Fact]
    public void ConfigureFileLoggerGivenFilePathReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }
}
