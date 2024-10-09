using System;

namespace Logger;

public class LogFactory
{
    public BaseLogger? CreateLogger(string className)
    {
        ArgumentNullException.ThrowIfNull(className);
        return new FileLogger() { ClassName = className };
    }
}
