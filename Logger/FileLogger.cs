using System;
using System.Globalization;
using System.IO;


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
        var logEntry = string.Format("{0} {1} {2}: {3}{4}",
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
            ClassName,
            level,
            message,
            Environment.NewLine);

        File.AppendAllText(_filePath, logEntry);
    }

}
