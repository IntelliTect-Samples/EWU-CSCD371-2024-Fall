using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {

        public string? Path { get; private set; }

        public ConsoleLogger()
        {
        }

        public override void Log(LogLevel logLevel, string message)
        {
            //get caller name
            // get create output string
            //Missing the functionality to get calling class name.
            Console.WriteLine(CreateOutputString(logLevel, message, DateTime.Now, this.ClassName));
        }

        public string? GetCallingClassName([CallerFilePath] string callerFilePath = "")
        {
            return System.IO.Path.GetFileNameWithoutExtension(callerFilePath);
        }

        public string CreateOutputString(LogLevel logLevel, string message, DateTime dateTime, string? caller)
        {
            string baseString = $"{dateTime} {caller} {logLevel}: {message}";
            return baseString;
        }
    }
}
