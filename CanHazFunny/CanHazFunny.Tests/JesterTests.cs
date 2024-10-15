using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    // Moq Quickstart: https://github.com/devlooped/moq/wiki/Quickstart

    [TestMethod]
    public void TellJoke_TryJokes_Success()
    {
        // Arrange
        string configurableJoke = "Funny joke"; // Configurable

        Console.WriteLine("Test");
        // Mock joke service
        var jokeServiceMock = new Mock<JokeService>();

        Console.WriteLine("Test2");

        jokeServiceMock.Setup(js => js.GetJoke()).Returns(configurableJoke);

        Console.WriteLine("Test3");

        // Mock console output service
        var consoleOutputServiceMock = new Mock<ConsoleOutputService>();
        consoleOutputServiceMock.Setup(x => x.WriteJoke(configurableJoke));

        // Real Jester
        Jester jester = new(consoleOutputServiceMock.Object, jokeServiceMock.Object);

        // Act
        jester.TellJoke();                      // Have the jester write a joke to console
        var stringWriter = new StringWriter();  // Creating a stringWriter to capture output
        Console.SetOut(stringWriter);           // Get the console output

        // Assert
        var output = stringWriter.ToString();
        Assert.AreEqual(configurableJoke, output);
    }
}
