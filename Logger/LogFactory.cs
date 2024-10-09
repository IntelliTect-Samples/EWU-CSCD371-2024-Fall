using System;

namespace Logger;

public class LogFactory
{
    public string? FilePath { get; private set; }

    public void ConfigureFileLogger(string? filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }
        FilePath = filePath;
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