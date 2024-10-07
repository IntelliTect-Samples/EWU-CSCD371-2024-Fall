using System;

namespace Logger;

public class LogFactory
{
    public string _filepath = string.Empty;

    public void ConfigureFileLogger(string filePath)
    {
        _filepath = filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        if (_filepath == null)
        {
            return null;
        }
        return new FileLogger(_filepath);
    }
}