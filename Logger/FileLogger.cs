using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger(string filePath) : BaseLogger
    {
        private string FilePath { get; } = filePath;

        public override void Log(LogLevel logLevel, string message)
        {
            //Format ex: "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            string log = $"{DateTime.UtcNow} UTC {ClassName} {logLevel}: {message}{Environment.NewLine}";
            //Print log message to file
            File.AppendAllText(FilePath, log);
        }
    }
}
