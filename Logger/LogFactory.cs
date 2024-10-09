using System;

namespace Logger;

public class LogFactory
{
    private string? _filePath;

    public string ConfigureFilePath(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        _filePath = filePath;
        return _filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        ArgumentNullException.ThrowIfNull(className);

        //If no file path is configured, return null
        if (string.IsNullOrWhiteSpace(_filePath))
        {
            return null;
        }

        return new FileLogger(_filePath) { ClassName = className };
    }
}
