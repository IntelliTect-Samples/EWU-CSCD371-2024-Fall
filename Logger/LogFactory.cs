using System;
using System.IO;
using System.Reflection;

namespace Logger;

public class LogFactory
{

    private string? FilePath { get; set; }

    public void ConfigureFileLogger()
    {
        // Get assembly Path and combine with txt file
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        FilePath = Path.Combine(assemblyPath, "file.txt");
    }
    // Creates Logger unless File Path is Null
    public BaseLogger? CreateLogger(string? className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            return null;
        }

        return new FileLogger(FilePath, className ?? string.Empty);
    }
}
