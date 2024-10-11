using System;

namespace Logger;

public class LogFactory
{

    private string? FilePath { get; set; }
    public BaseLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath)) 
        {
            return null;
        }

        FileLogger logger = new FileLogger(FilePath)
        { 
            ClassName = className
        };

        return logger;

    }

    public void ConfigureFileLogger(string filePath)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
        FilePath = filePath;
    }
}
