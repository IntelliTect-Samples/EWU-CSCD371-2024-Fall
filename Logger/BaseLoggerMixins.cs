namespace Logger;

using System;


public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Error, string.Format(message, args));
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Warning, string.Format(message, args));
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Information, string.Format(message, args));
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Debug, string.Format(message, args));
    }
}
