using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(object value, string v)
    {
        if (value is null) throw new ArgumentNullException("BaseLoggerMixins.Error was passed in anull for value");
    }
}
