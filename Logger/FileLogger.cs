using System;
using System.IO;

namespace Logger
{
    // FileLogger class logs messages to a file
    // derives from BaseLogger
    public class FileLogger : BaseLogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            var logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

            // Check if the file exists, if not create it and write to it
            if (!File.Exists(_filePath))
            {
                using (StreamWriter sw = File.CreateText(_filePath))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                // If the file exists, append the log message
                using (StreamWriter sw = File.AppendText(_filePath))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }
    }
}