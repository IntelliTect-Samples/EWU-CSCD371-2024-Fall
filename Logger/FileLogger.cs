using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Logger;
public class FileLogger : BaseLogger
{
    // readonly so that it can't be changed after the object is constructed.
    private readonly string _filePath;
    public FileLogger (string filePath)
    {
        _filePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";
        File.AppendAllText(_filePath, logMessage + Environment.NewLine);
    }
}