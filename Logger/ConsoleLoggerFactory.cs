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
            ConsoleLogger consoleLogger = new() {ClassName = nameof(ConsoleLoggerFactory).ToLowerInvariant()};
            return consoleLogger;
        }
    }
}

