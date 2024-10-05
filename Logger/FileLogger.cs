using System;
using System.Globalization;
using System.IO;
using System.Text;


namespace Logger;


public class FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public override void Log(LogLevel level, string message)
    {
        //var logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {ClassName} {level}: {message}{Environment.NewLine}";
        
        var logEntryBuilder = new StringBuilder();
        logEntryBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        logEntryBuilder.Append(" ");
        logEntryBuilder.Append(ClassName);
        logEntryBuilder.Append(" ");
        logEntryBuilder.Append(level);
        logEntryBuilder.Append(": ");
        logEntryBuilder.Append(message);
        logEntryBuilder.Append(Environment.NewLine);

        string logEntry = logEntryBuilder.ToString();

        File.AppendAllText(_filePath, logEntry);
    }

}
