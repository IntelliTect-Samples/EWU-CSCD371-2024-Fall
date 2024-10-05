using System;

namespace Logger;

using System.IO;
using System.Reflection;

public class LogFactory
{
    private string? FilePath { get; set; }

    public void ConfigureFileLogger()
    {
        // Set a valid, writable file path
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

        // You can also add a null check to ensure the file path is valid
        if (string.IsNullOrEmpty(FilePath))
        {
            throw new InvalidOperationException("File path is not configured correctly.");
        }
    }

    public BaseLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;  // Ensure that null is handled
        }

        return new FileLogger(FilePath)
        {
            ClassName = className
        };
    }
}