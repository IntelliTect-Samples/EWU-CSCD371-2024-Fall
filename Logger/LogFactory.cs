using System;
using System.IO;

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
        char[] separators = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
        string[] pathParts = filePath.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        FilePath = Path.Combine(pathParts);
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