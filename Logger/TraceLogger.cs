using System.Diagnostics;
using System;

namespace Logger;

public class TraceLogger : BaseLogger
{
    public TraceLogger(string className)
    {
        ClassName = className;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

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
