using System.Diagnostics;
using System;
using System.IO;

namespace Logger;

public class TraceLogger : BaseLogger
{
    private readonly FileLogger _fileLogger;
    public TraceLogger(string className, FileLogger fileLogger)
    {
        ClassName = className;
        _fileLogger = fileLogger ?? throw new ArgumentNullException(nameof(fileLogger), "FileLogger cannot be null.");
    }

    //Publicly exposing FileLogger as a read-only property for testing purposes
    public FileLogger FileLogger => _fileLogger;

    public override void Log(LogLevel logLevel, string message)
    {
        string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";
        _fileLogger.Log(logLevel, message);

        switch (logLevel)
        {
            case LogLevel.Error:
                Trace.TraceError(logMessage);
                break;
            case LogLevel.Warning:
                Trace.TraceWarning(logMessage);
                break;
            case LogLevel.Information:
                Trace.TraceInformation(logMessage);
                break;
            case LogLevel.Debug:
                Trace.WriteLine(logMessage, "Debug");
                break;
            default:
                Trace.WriteLine(logMessage, logLevel.ToString());
                break;
        }
    }
}
