using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System;
namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args) // takes in the BaseLogger, the message string, and the args array
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(LogLevel.Error, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(LogLevel.Warning, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(LogLevel.Information, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(LogLevel.Debug, string.Format(CultureInfo.InvariantCulture, message, args));
    }
}
