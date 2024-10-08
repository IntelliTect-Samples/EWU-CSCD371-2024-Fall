using System;
using System.IO;

namespace Logger;

public class FileLogger: BaseLogger {
    public string FilePath;
    public override string ClassName { get; }

    public FileLogger(string filePath, string className)
    {
        FilePath = filePath;
        ClassName = className;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logEntry = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {ClassName} {logLevel}: {message}";
        File.AppendAllText(FilePath, logEntry + Environment.NewLine);
    }

}
