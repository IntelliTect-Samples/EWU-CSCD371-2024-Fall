using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System;
namespace Logger;

public class FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string path = Path.Combine(_filePath, "DebugLog.txt");
        if (string.IsNullOrEmpty(_filePath))
        {
            throw new ArgumentNullException(_filePath);
        }
        using (var fs = new StreamWriter(path, true))
        {
            fs.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {nameof(ClassName)} {logLevel} {message}{Environment.NewLine}");
        }
    }
}