using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override ConsoleLogger? CreateLogger()
        {
            ConsoleLogger consoleLogger = new ConsoleLogger() { ClassName = nameof(ConsoleLoggerFactory).ToLower() };
            return consoleLogger;
        }
    }
}

