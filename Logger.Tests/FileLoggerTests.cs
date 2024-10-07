using System.ComponentModel;
using System.IO;
using System.Runtime.Intrinsics.X86;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

using static System.Formats.Asn1.AsnWriter;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void CreateLogger_Successful()
    {
        string validFilePath = "xxxx";
        FileLogger.CreateFileLog(validFilePath);

        Assert.AreEqual<>;

    }

    [TestMethod]
    public void CreateLogger_InvalidFilePath()
    {
        string invalidFilePath = null;
        FileLogger.CreateFileLog(invalidFilePath);


        Assert.ThrowsException<>;
    }
}

/* Create a `FileLogger` that derives from `BaseLogger`. It should take in a path to a file to write the log message to. When its `Log` method is called, it should **append** messages on their own line in the file. The output should include all of the following:
  - The current date/time ❌✔
  - The name of the class that created the logger ❌✔
  - The log level ❌✔
  - The message ❌✔
  - The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
- The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a** private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. ❌✔
- If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`. ❌✔
- Inside of `BaseLoggerMixins` implement** extension methods** on `BaseLogger` for
  - `Error`, ❌✔
  - `Warning`, ❌✔
  - `Information`, and ❌✔
  - `Debug`. ❌✔
*/