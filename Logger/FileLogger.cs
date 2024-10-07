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
            //get caller name
            // get create output string
            FileStream outFile = new(logLevel+".txt",FileMode.Append);
            StreamWriter writer  = new StreamWriter(outFile);
            writer.WriteLine(message);
            writer.Close();
            outFile.Close();

        }

        //I want to be able to call this method statically and get the correct input
        //Consider exploring .. directory traversal?
        public string GetCallingClassName([CallerFilePath] string callerFilePath = "")
        {
            //IDE does not like this line unless you include System.IO despite the using statement above
            return System.IO.Path.GetFileNameWithoutExtension(callerFilePath);
        }

        public string CreateOutputString(LogLevel logLevel, string message, DateTime dateTime, string caller)
        {
            //consider modifying test and method so that datetime is generated here instead?
            //In this case, the method relies on outside information to generate its calling class name
            //Is there a way to get the calling class name without relying on outside information
            //

            string baseString = $"{dateTime} {caller} {logLevel}: {message}";
            return baseString;
        }
    }
}
