using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{

    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_CreateFileLogger_Pass()
        {
            // Arrange
            var logFactory = new LogFactory();
            logFactory.ConfigureFileLogger();

            // Act
            var logger = logFactory.CreateLogger("TestClass");

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, typeof(FileLogger));

        }


    }
}