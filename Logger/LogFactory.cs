using System;
using System.IO;
using System.Runtime.InteropServices;

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
        char[] separators = { '/', '\\' };
        var pathParts = path.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            if (pathParts.Length > 0 && pathParts[0].Length == 2 && pathParts[0][1] == ':')
            {
                pathParts[0] = "/" + pathParts[0][0];
            }
        }
        return Path.Combine(pathParts);
    }
}