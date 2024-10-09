using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class TestLoggerFactory : LoggerFactory
    {
        public override TestLogger? CreateLogger(string callingClassName)
        {
        TestLogger testLogger = new TestLogger() {ClassName = callingClassName };
        return testLogger;
        }
    }
}
