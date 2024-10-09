using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Logger
{
public class FileLogger : BaseLogger
    {

        public string? Path { get; private set; }

        public FileLogger(string? path)
        {
            ArgumentNullException.ThrowIfNull(path);
            Path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            //set info in file.
            //calls format to append datetime to message
            //try to append line using path to file
            //get caller name
            // get create output string
            //Missing the functionality to get calling class name.
            if (!Directory.Exists(Path!))
            {
                Directory.CreateDirectory(Path!);
            }

            string path = System.IO.Path.Combine(Path!, logLevel + ".txt");
            message = DateTime.Now + " " + ClassName+ " " + logLevel + ": " + message;
            File.AppendAllText(path, message);
        }

        
        public static string CreateOutputString(LogLevel logLevel, string message, DateTime dateTime, string? caller)
        {
            string baseString = $"{dateTime} {caller} {logLevel}: {message}";
            return baseString;
        }
    }
}
