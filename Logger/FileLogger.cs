using System;
using System.Collections.Generic;
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
        }
    }
}
