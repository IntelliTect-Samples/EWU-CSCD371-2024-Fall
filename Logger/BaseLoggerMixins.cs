using System;

namespace Logger;

// Implements Extension methods for the four LogLevels
public static class BaseLoggerMixins
{
    //  Each of these methods should take in a `string` for the message, as well as a
    //  **parameter array** of arguments for the message.
    //  Each of these extension methods is expected to be a shortcut for calling the
    //  `BaseLogger.Log` method, by automatically supplying the appropriate `LogLevel`.
    //  These methods should throw an exception if the `BaseLogger` parameter is null.
    //  There are a couple example unit tests to get you started.

    //private static BaseLogger Logger { get; } = new FileLogger();
    
    // Error
    public static void Error(this BaseLogger? Logger, string message, params string[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(Logger);

        // Call BaseLogger.Log passing in the Error LogLevel


        Logger.Log(LogLevel.Error, message);
    }

    // Warning
    public static void Warning(this BaseLogger? Logger, string message, params string[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(Logger);

        Logger.Log(LogLevel.Warning, message);
    }

    // Information
    public static void Information(this BaseLogger? Logger, string message, params string[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(Logger);

        Logger.Log(LogLevel.Information, message);
    }

    // Debug
    public static void Debug(this BaseLogger? Logger, string message, params string[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(Logger);

        Logger.Log(LogLevel.Debug, message);
    }

}
