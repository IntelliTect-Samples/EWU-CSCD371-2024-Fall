using System;

namespace Logger;

public class LogFactory
{
    private string? FilePath {  get; set; }

    public string ConfigureFilePath(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        FilePath = filePath;
        return FilePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        ArgumentNullException.ThrowIfNull(className);

        //If no file path is configured, return null
        if (string.IsNullOrWhiteSpace(FilePath))
        {
            return null;
        }

        return new FileLogger(FilePath) { ClassName = className };
    }
}
