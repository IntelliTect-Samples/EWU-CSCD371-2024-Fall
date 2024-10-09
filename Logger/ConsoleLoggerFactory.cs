using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override ConsoleLogger? CreateLogger(string callingClassName)
        {
            ConsoleLogger consoleLogger = new() {ClassName = callingClassName };
            return consoleLogger;
        }
    }
}

 