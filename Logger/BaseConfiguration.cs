namespace Logger;
/// <summary>
///Contains:<br/>
///<seealso cref="LogSource"/><br/>
///<seealso cref="BaseLoggerConfiguration(string)"/><br/>
///
/// </summary>
///<remarks>
/// Implements <seealso cref="ILoggerConfiguration"/>
/// </remarks>
//TODO: Remove unsued class BaseLoggerConfiguration or implement constructor overload in BaseLogger.

public class BaseLoggerConfiguration : ILoggerConfiguration
{
    public BaseLoggerConfiguration(string logSource) => LogSource = string.IsNullOrWhiteSpace(logSource)
            ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
            : logSource;
    /// <summary>
    ///Implementation from <seealso cref="ILoggerConfiguration.LogSource"/>
    /// </summary>
    public string LogSource { get; }
}