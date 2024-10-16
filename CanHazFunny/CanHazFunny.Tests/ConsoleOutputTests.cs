using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests
{
    public class ConsoleOutputTests
    {
        [Fact]
        public void WriteJoke_ToConsole_WritesCorrectJoke()
        {
            // Arrange
            var consoleOutput = new ConsoleOutputService();
            var joke = "Funny Joke";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            consoleOutput.WriteJoke(joke);

            // Assert
            Assert.Equal(joke, stringWriter.ToString().Trim());

            Console.SetOut(Console.Out);
        }
    }
}

