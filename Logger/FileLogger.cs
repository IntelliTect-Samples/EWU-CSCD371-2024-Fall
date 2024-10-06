using System;
using System.IO;

namespace Logger;

public class FileLogger: BaseLogger {
    private string filePath;

    public FileLogger(string _filePath) {
        filePath = _filePath;
    }

     public void Log(string logLevel, string message)
    {
        string logEntry = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {ClassName} {logLevel}: {message}";
        File.AppendAllText(filePath, logEntry + Environment.NewLine);
    }
}
