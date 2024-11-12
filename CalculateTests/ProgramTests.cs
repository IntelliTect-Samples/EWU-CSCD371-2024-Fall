using Calculate;
using Xunit;

namespace CalculateTests;

public class ProgramTests
{
    private string output = string.Empty;
    private string input = "Test Input";

    [Fact]
    public void Program_WriteLineAndReadLine_InvokedCorrectly()
    {
        // Arrange
        var program = new Program(
            writeLine: text => output = text,
            readLine: () => input
        );

        // Act
        program.WriteLine("Test Output");
        var result = program.ReadLine();

        // Assert
        Assert.Equal("Test Output", output);
        Assert.Equal("Test Input", result);
    }
}
