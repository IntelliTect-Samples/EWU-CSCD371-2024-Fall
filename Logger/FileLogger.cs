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

        public string Path { get; private set; }

        public FileLogger(string path)
        {
            if (path is null) throw new ArgumentNullException();
            this.Path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            //set info in file.
            //calls format to append datetime to message
            //try to append line using path to file
        }

        public string GetCallingClassName([CallerFilePath] string callerFilePath = "")
        {
            return System.IO.Path.GetFileNameWithoutExtension(callerFilePath);
        }

        public string CreateOutputString(LogLevel logLevel, string message, DateTime dateTime, string caller)
        {
            //date time AM/PM ClassName logLevel: message
            //add in datetime 
            //Example: 10/7/2019 12:38:59 AM
            //Add 
            //$()
            //consider modifying test and method so that datetime is generated here instead
            string baseString = $"{dateTime} {caller} {logLevel}: {message}";
            return baseString;
        }
    }
}
