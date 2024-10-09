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
    
    // Error extension method
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(logger);

        string? newMessage = string.Format(message, args);
        // Call to Log method passing in the Error LogLevel     
        logger.Log(LogLevel.Error, message);
    }


    // Warning extension method
    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(logger);

        // Call to Log method passing in the Warning LogLevel     
        logger.Log(LogLevel.Warning, message);
    }


    // Information extension method
    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(logger);

        // Call to Log method passing in the Information LogLevel
        logger.Log(LogLevel.Information, message);
    }


    // Debug extension method
    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        // Throw Exception if BaseLogger param is null
        ArgumentNullException.ThrowIfNull(logger);

        // Call to Log method passing in the Debug LogLevel
        logger.Log(LogLevel.Debug, message);
    }
}
