using System;
using System.IO;

namespace Logger;

public class FileLogger: BaseLogger {
    public string _filePath { get; }
    public override string _className { get; }

    public FileLogger(string filePath, string className)
    {
        _filePath = filePath;
        _className = className;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logEntry = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {_className} {logLevel}: {message}";
        File.AppendAllText(_filePath, logEntry + Environment.NewLine);
    }

}
