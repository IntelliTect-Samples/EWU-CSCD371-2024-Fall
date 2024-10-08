using System;
using System.Globalization;

namespace Logger;

public static class BaseLoggerMixins
{
    //This class is used to extend the functionality from BaseLogger,
    //without modifiying the original class, using a concept called Extension Methods

    //The functionality we are extending is to take in strings and format them for the BaseLogger class

    //We expect our Extension Methods to have paramaters of:
    //MethodName(This BaseLogger logger, String v, param var[] stuffToInsert)
    //"This BaseLogger logger" is indicating this method is actually really an extension of abstract BaseLogger,
    //and thus these method can be used as a Baselogger method in the directory
    //ex: BaseLoggerChild.Error()



    private static void CheckAndLog(BaseLogger? logger, string baseMessage, object[] objectsToInsert, LogLevel level)
    {
        ArgumentNullException.ThrowIfNull(logger);
        if (baseMessage is null) baseMessage = "Null message passed in";
        if (objectsToInsert is null) objectsToInsert = Array.Empty<object>();
        string formatResult = string.Format(CultureInfo.InvariantCulture, baseMessage, objectsToInsert);
        logger.Log(level, formatResult);

    }

    public static void Error(this BaseLogger? logger, string baseMessage, params object[] objectsToInsert)
    {
         CheckAndLog(logger, baseMessage, objectsToInsert,LogLevel.Error);
   
    }
    public static void Warning(this BaseLogger? logger, string baseMessage, params object[] objectsToInsert)
    {
        CheckAndLog(logger, baseMessage, objectsToInsert,LogLevel.Warning);
    }

    
    public static void Information(this BaseLogger? logger, string baseMessage, params object[] objectsToInsert)
    {
        CheckAndLog(logger, baseMessage, objectsToInsert,LogLevel.Information);
    
    }
    public static void Debug(this BaseLogger? logger, string baseMessage, params object[] objectsToInsert)
    {
        CheckAndLog(logger, baseMessage, objectsToInsert, LogLevel.Debug);

    }

}
    