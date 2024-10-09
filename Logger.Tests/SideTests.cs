using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class SideTests
    {
        [TestMethod]
        [DataRow("C:\\Users\\Nina\\logger", LogLevel.Error, "Hello!")]
        [DataRow("C:\\Users\\Nina\\logger\\internalFolder", LogLevel.Error, "Hello!")]
        //[DataRow("C:\\Users\\ericm\\repos\\EWU-CSCD371-2024-Fall\\Logger.Tests\\bin\\Debug\\net7.0\\testfile.txt")]
        //[DataRow("C:\\Users\\ericm\\repos\\EWU-CSCD371-2024-Fall\\Logger.Tests\\bin\\Debug\\net7.0", LogLevel.Error, "Hello!")]
        public void TestFileCanBeAppended(string path, LogLevel logLevel, string message)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Arrange
            path = System.IO.Path.Combine(path, logLevel + ".txt");

            string appendText = " Appended content.";
     
            // Act
            File.AppendAllText(path, appendText);
            string result = File.ReadAllText(path);

            // Assert
            Assert.IsTrue(result.Contains(appendText), "The file could not be appended.");
        }
    }
}
