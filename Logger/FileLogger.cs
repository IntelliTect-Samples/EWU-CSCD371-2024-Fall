using System;
using System.IO;

namespace Logger;

public class FileLogger: BaseLogger {
    private string _filePath;
    public override string ClassName { get; }

    public string FilePath
    {
        get => _filePath;
        set => _filePath = value;
    }

    public FileLogger(string filePath, string className)
    {
        _filePath = filePath;
        ClassName = className;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logEntry = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {ClassName} {logLevel}: {message}";
        File.AppendAllText(_filePath, logEntry + Environment.NewLine);
    }

}
