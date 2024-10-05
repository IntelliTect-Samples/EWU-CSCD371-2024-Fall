using System;

namespace Logger;

using System.IO;
using System.Reflection;

public class LogFactory
{
    private string? FilePath { get; set; }

    public void ConfigureFileLogger()
    {
        // Set the file path to a writable location, ensuring it's not null
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");
    }

    public BaseLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            throw new InvalidOperationException("FilePath is not configured.");
        }

        return new FileLogger(FilePath)
        {
            ClassName = className
        };
    }
}