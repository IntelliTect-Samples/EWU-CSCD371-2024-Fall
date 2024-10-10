using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string FilePath { get; }

        public FileLogger(string? filePath, string className)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath), "FilePath cannot be Null.");
            FilePath = filePath;
            ClassName = className;
        }


        public override void Log(LogLevel logLevel, string message)
        {
            var logAppend = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} {ClassName} {logLevel}: {message}{Environment.NewLine}";
            File.AppendAllText(FilePath, logAppend);
        }
    }


}
