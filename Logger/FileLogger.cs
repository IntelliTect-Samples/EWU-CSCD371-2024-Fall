using System;
using System.Globalization;
using System.IO;

namespace Logger;


public class FileLogger : BaseLogger
{
    private string? FilePath { get; } 

    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public override void Log(LogLevel level, string message)
    {
        
        if (!string.IsNullOrEmpty(FilePath))
        {
            var logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {ClassName} {level}: {message}{Environment.NewLine}";

            File.AppendAllText(FilePath, logEntry);
        }
        else
        {
            // Handle the null case, e.g., throw an exception or log a warning
            throw new InvalidOperationException("FilePath cannot be null or empty.");
        }
    }

}