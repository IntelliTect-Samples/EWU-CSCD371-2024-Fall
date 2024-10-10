namespace Logger;

using System;
using System.Globalization;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string? message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Error, string.Format(CultureInfo.InvariantCulture, message ?? string.Empty, args));
    }

    public static void Warning(this BaseLogger logger, string? message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Warning, string.Format(CultureInfo.InvariantCulture, message ?? string.Empty, args));
    }

    public static void Information(this BaseLogger logger, string? message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Information, string.Format(CultureInfo.InvariantCulture, message ?? string.Empty, args));
    }

    public static void Debug(this BaseLogger logger, string? message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Debug, string.Format(CultureInfo.InvariantCulture, message ?? string.Empty, args));
    }
}
