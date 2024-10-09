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
        [DataRow("C:\\Users\\ericm\\temp", LogLevel.Error, "Hello!")]
        //[DataRow("C:\\Users\\ericm\\repos\\EWU-CSCD371-2024-Fall\\Logger.Tests\\bin\\Debug\\net7.0\\testfile.txt")]
        //[DataRow("C:\\Users\\ericm\\repos\\EWU-CSCD371-2024-Fall\\Logger.Tests\\bin\\Debug\\net7.0", LogLevel.Error, "Hello!")]
        public void TestFileCanBeAppended(string filePath, LogLevel logLevel, string message)
        {
            // Arrange
            filePath = System.IO.Path.Combine(filePath, logLevel + ".txt");
            string initialText = "Initial content.";
            string appendText = " Appended content.";

            // Ensure the file is created and has initial content
            File.WriteAllText(filePath, initialText);

            // Act
            File.AppendAllText(filePath, appendText);
            string result = File.ReadAllText(filePath);

            // Assert
            Assert.IsTrue(result.Contains(appendText), "The file could not be appended.");
        }
    }
}
