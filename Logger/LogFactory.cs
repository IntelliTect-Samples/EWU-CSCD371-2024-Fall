using System;

namespace Logger;

public class LogFactory
{
    private string _filepath = string.Empty;

    public void ConfigureFileLogger(string? filePath)
    {
        _filepath = filePath ?? string.Empty;
    }
    public FileLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(_filepath))
        {   
            return null;
        }
        return new FileLogger(_filepath) { ClassName = className };
    }
    public string GetFilePath()
    {
        return _filepath;
    }
}