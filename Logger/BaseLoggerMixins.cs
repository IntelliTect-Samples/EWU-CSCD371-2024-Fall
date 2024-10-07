namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args) // takes in the BaseLogger, the message string, and the args array
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(string.Format(message, args), LogLevel.Error);
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(string.Format(message, args), LogLevel.Warning);
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(string.Format(message, args), LogLevel.Info);
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        if (logger == null) throw new ArgumentNullException(nameof(logger));
        logger.Log(string.Format(message, args), LogLevel.Debug);
    }
}
