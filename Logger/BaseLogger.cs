namespace Logger;

// We do not implement ILogger here because you can
// only have abstract static methods on interfaces.
/// <summary>
/// Abstract class.
/// </summary>
public abstract class BaseLogger
{
    ///<returns>Calling class name</returns>
    public string LogSource { get; }
    /// <summary>
    /// sets LogSource and returns. Fails if LogSource is null or white space.
    /// </summary>
    /// <param name="logSource"></param>
    /// <exception cref="ArgumentException">Throws exception if null</exception>
    public BaseLogger(string logSource) => LogSource = string.IsNullOrWhiteSpace(logSource)
            ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
            : logSource;

    public abstract void Log(LogLevel logLevel, string message);

    // You can only have abstract static methods on interfaces.
    // public abstract static ILogger CreateLogger(in ILoggerConfiguration configuration);
}