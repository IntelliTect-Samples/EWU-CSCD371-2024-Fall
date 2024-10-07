﻿using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(message, args);

        logger.Log(LogLevel.Error, formattedMessage);
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(message, args);

        logger.Log(LogLevel.Warning, formattedMessage);
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(message, args);

        logger.Log(LogLevel.Information, formattedMessage);
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "The logger instance can't be null.");
        }

        string formattedMessage = string.Format(message, args);

        logger.Log(LogLevel.Debug, formattedMessage);
    }
}