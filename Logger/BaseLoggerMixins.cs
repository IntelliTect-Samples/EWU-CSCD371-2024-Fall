using System;

namespace Logger;

public static class BaseLoggerMixins
{
    //This class is used to extend the functionality from BaseLogger,
    //without modifiying the original class, using a concept called Extension Methods

    //The functionality we are extending is to take in strings and format them for the BaseLogger class
    
    //We expect our Extension Methods to have paramaters of:
    //MethodName(This BaseLogger logger, String v, param var[])
    //"This BaseLogger logger" is indicating this method is actually really an extension of abstract BaseLogger,
    //and thus these method can be used as a Baselogger method in the directory
    //ex: BaseLoggerChild.Error()
    
    public static void Error(object value, string v)
    {
        if (value is null) throw new ArgumentNullException("BaseLoggerMixins.Error was passed in anull for value");
    }
}
