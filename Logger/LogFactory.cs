using System;

namespace Logger;

public class LogFactory
{
    public string? FilePath { get; private set; }

    public void ConfigureFileLogger(string? filePath)
    {
        FilePath = filePath ?? string.Empty;
    }
    public FileLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {   
            return null;
        }
        return new FileLogger(FilePath) { ClassName = className };
    }
}