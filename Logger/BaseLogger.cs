using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System;
namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);

    public string? ClassName { get; set; }
}


public class  FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string path = Path.Combine(_filePath,"DebugLog.txt");
        if (string.IsNullOrEmpty(_filePath))
        {
            throw new ArgumentNullException(nameof(path));
        }
        using (var fs = new StreamWriter(path, true))  // We need a have a way to name the file I think that this is making the file in an unspecified location named by the var _Path instead.
        {
            fs.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {nameof(ClassName)} {logLevel} {message}{Environment.NewLine}");
        }
    }
    



    /*     

            /*Appends to Baselogger   
             -The current date/time ❌✔
            -The name of the class that created the logger ❌✔
            - The log level ❌✔
            - The message ❌✔ The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            
        }*/
}

