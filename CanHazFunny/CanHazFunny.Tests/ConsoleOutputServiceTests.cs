using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class ConsoleOutputServiceTests
{

    private const int tabSize = 4;
    private const string usageText = "Usage: INSERTTABS inputfile.txt outputfile.txt";

    [Fact]
    public void WriteJoke_ReturnsJoke_Success()
    {
        // Arrange
        var joke = "Funny Joke";
        var consoleOutput = new ConsoleOutputService();

        var inputContent = "Example input    with spaces.";
        var expectedOutput = "Example input\twith spaces.";

        // Use StringWriter instead of StreamWriter
        using (var writer = new StringWriter())
        using (var reader = new StringReader(inputContent))
        {
            Console.SetOut(writer);
            Console.SetIn(reader);

            // Act
            string? line;
            while ((line = Console.ReadLine()) != null)
            {
                string newLine = line.Replace(("").PadRight(tabSize, ' '), "\t");
                Console.WriteLine(newLine);
            }

            consoleOutput.WriteJoke(joke);

            // Assert the joke is written in the output
            var output = writer.ToString();
            Assert.Contains(joke, output);
            Assert.Contains(expectedOutput, output);
        }

        // Recover the standard output stream
        var standardOutput = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
        Console.SetOut(standardOutput);
        Console.WriteLine("INSERTTABS has completed the processing.");
    }
}
