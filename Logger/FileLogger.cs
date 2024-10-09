using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string _filePath { get; }
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public override void Log(LogLevel logLevel, string message)
        {
            //Format ex: "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            string formattedMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

            //Print log message to file
            File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
        }
    }
}
