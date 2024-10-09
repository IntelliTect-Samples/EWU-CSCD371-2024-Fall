using System;
using System.Globalization;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Error, string.Format(new CultureInfo("en-US"),message,args));
    }
    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Warning, string.Format(new CultureInfo("en-US"), message, args));
    }
    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Information, string.Format(new CultureInfo("en-US"), message, args));
    }
    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger is null");
        }
        logger.Log(LogLevel.Debug, string.Format(new CultureInfo("en-US"), message, args));
    }

}
