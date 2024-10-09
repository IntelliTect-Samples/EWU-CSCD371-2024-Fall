using System;
using System.IO;
using System.Reflection;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
       

        public override void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }
    }


}
