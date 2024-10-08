using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

using static System.Formats.Asn1.AsnWriter;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void CreateLogger_IsNotNull()
    {
        FileLogger TestLogger = new FileLogger(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        Assert.IsNotNull(TestLogger);

    }

    [TestMethod]
    public void CreateLogger_InvalidFilePath()
    {

        FileLogger TestLogger = new FileLogger("");



        Assert.ThrowsException<System.ArgumentNullException>(() => TestLogger.Log(LogLevel.Debug, "Exemption was thrown")); 


    }
}
