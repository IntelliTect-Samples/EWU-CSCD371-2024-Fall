using System;
using System.IO;

namespace Logger
{
    // FileLogger class logs messages to a file
    // derives from BaseLogger
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; set; } = "";

        public override void Log(LogLevel logLevel, string message)
        {
            var logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

            // Check if the file exists, if not create it and write to it
            if (!File.Exists(FilePath))
            {
                using (StreamWriter sw = File.CreateText(FilePath))
                {
                    sw.WriteLine(logMessage);
                }
            }
            else
            {
                // If the file exists, append the log message
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(logMessage);
                }
            }
        }
    }
}