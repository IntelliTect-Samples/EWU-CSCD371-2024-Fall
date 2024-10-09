using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

using System;
using System.IO;
using System.Reflection;

namespace Logger.Tests;



[TestClass]
public class FileLoggerTests
{
    private string _logFilePath = string.Empty;

    [TestInitialize]
    public void Setup()
    {
        //set up loog file path
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        _logFilePath = Path.Combine(assemblyPath, "testlog.txt");

        // clear file contents if it already exists 
        if (File.Exists(_logFilePath))
        {
            File.Delete(_logFilePath);
        }
    

    }
    //[TestMethod]
    //public string



  
}
