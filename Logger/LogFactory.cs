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

        // Normalize the filePath to ensure it is correctly formatted for the current OS
        FilePath = NormalizePath(filePath);
    }

    public FileLogger? CreateLogger(string className)
    {
        if (string.IsNullOrEmpty(FilePath))
        {   
            return null;
        }
        return new FileLogger(FilePath) { ClassName = className };
    }

    private static string NormalizePath(string path)
    {
        // Split the path by both possible directory separators
        char[] separators = new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
        var pathParts = path.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        // Combine it back into a normalized path
        return Path.Combine(pathParts);
    }
}