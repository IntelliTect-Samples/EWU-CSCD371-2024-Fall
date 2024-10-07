using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Log(this BaseLogger logger, LogLevel level, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(message, args);
        logger.Log(level, formattedMessage);
    }
}