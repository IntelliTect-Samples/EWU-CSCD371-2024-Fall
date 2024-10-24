namespace Logger;
/// <summary>
/// Extends <seealso cref="BaseLogger"/><br/>
/// <br/>
/// Below methods allow for easier calling of <seealso cref="BaseLogger.Log(Logger.LogLevel, string)"/>
/// <br/>
/// Contains:<br/>
/// <seealso cref="Error"/><br/>
/// <seealso cref="Warning"/><br/>
/// <seealso cref="Information"/><br/>
/// <seealso cref="Debug"/><br/>
/// </summary>
public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Error, message);
    public static void Warning(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Warning, message);
    public static void Information(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Information, message);
    public static void Debug(this BaseLogger logger, string message) =>
        (logger??throw new ArgumentNullException(nameof(logger))).Log(LogLevel.Debug, message);
}