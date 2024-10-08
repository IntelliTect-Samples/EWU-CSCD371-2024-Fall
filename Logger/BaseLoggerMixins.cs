using System;
using System.Globalization;

namespace Logger;

public static class BaseLoggerMixins
{
    // General log method
    public static void Log(this BaseLogger logger, LogLevel level, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(CultureInfo.InvariantCulture, message, args);
        logger.Log(level, formattedMessage);
    }

    // Specific log methods
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        Log(logger, LogLevel.Error, message, args);
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        Log(logger, LogLevel.Warning, message, args);
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        Log(logger, LogLevel.Information, message, args);
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        Log(logger, LogLevel.Debug, message, args);
    }
}