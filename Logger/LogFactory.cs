using System;
using System.IO;
using System.Reflection;

namespace Logger;

public class LogFactory
{

    public string? FilePath { get; private set; }

    public void ConfigureFileLogger()
    {
        // Get assembly Path and combine with txt file
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        FilePath = Path.Combine(assemblyPath, "file.txt");
    }

    public BaseLogger? CreateLogger(string? className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;
        }

        return new FileLogger(FilePath, className ?? string.Empty);
    }
}
