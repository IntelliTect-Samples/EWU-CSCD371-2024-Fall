namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger
{
    public TestLogger(string logSource) : base(logSource) { }

    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = [];

    public static ILogger CreateLogger(in TestLoggerConfiguration configuration) =>
        new TestLogger(configuration.LogSource);

    static T ILogger.CreateLogger<T, U>(in U configuration) =>
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? (T)(object)CreateLogger(testLoggerConfiguration)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
