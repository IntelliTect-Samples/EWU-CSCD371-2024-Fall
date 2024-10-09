using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    public string FilePath { get; }  

    public FileLogger(string filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";
        File.AppendAllText(FilePath, logMessage + Environment.NewLine);
    }
}