using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{

    [TestClass]
    public class LogFactoryTests
    {

        private string LogFilePath { get; set; } = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            //set up logger file path
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            LogFilePath = Path.Combine(assemblyPath, "file.txt");

            // clear file contents if it already exists 
            if (File.Exists(LogFilePath))
            {
                File.Delete(LogFilePath);
            }
        }
        [TestMethod]
        public void CreateLogger_CreateFileLogger_Pass()
        {
            // arrange
            var logFactory = new LogFactory();
            logFactory.ConfigureFileLogger();

            // act
            var logger = logFactory.CreateLogger("TestClass");

            // assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, typeof(FileLogger));

        }

        [TestMethod]
        public void ConfigureFileLogger_FindCorrectFilePath_Pass()
        {
            //arrange
            var logFactory = new LogFactory();

            //act
            logFactory.ConfigureFileLogger();

            var filePath = typeof(LogFactory).GetProperty("FilePath", BindingFlags.NonPublic | BindingFlags.Instance);
            var filePathValue = filePath?.GetValue(logFactory) as string;

            //assert
            Assert.IsNotNull(filePathValue);
            Assert.AreEqual(filePathValue, LogFilePath);
        }

        [TestMethod]
        public void CreateLogger_CreateWithNullClassName_PassWithEmptyClassName() 
        {
            //arrange
            var logFactory = new LogFactory();
            string? nulled = null;
            //act
            logFactory.ConfigureFileLogger();
            var logger = logFactory.CreateLogger(nulled);

            //assert
            Assert.IsNotNull(logger);
            Assert.IsTrue(logger!.ClassName!.Equals(string.Empty, System.StringComparison.Ordinal));
        }

        [TestMethod]
        public void CreateLogger_CreateWithNullFilePath_Null() 
        {
            var logFactory = new LogFactory();
            
            // act
            var logger = logFactory.CreateLogger("TestClass");

            // assert
            Assert.IsNull(logger);
        }

    }
}