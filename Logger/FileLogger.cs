using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _filePath;
       

        public FileLogger(string? filePath, string className)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath), "FilePath cannot be Null.");
            _filePath = filePath;
            ClassName = className;
        }
       

        public override void Log(LogLevel logLevel, string message)
        {
            var logAppend = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {ClassName} {logLevel}: {message}{Environment.NewLine}";
            File.AppendAllText(_filePath, logAppend);
        }
    }


}
