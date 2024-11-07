namespace Calculate.Tests;

using Calculate.Core;

public class ProgramTests
{
    [Theory]
    [InlineData("Test input")]
    public void Constructor_LambdaCapture_InvokesProperties(string input)
    {
        // Arrange
        string capturedOutput = "";

        Program program = new()
        {
            WriteLine = (message) => capturedOutput = message,
            ReadLine = () => input
        };

        // Act
        program.WriteLine("Hello World!");
        string result = program.ReadLine();

        // Assert
        Assert.Equal("Hello World!", capturedOutput);
        Assert.Equal("Test input", result);
    }

    [Theory]
    [InlineData("Test input")]
    public void Constructor_ReaderAndWriter_InvokesProperties(string input)
    {
        // Arrange
        StringWriter writer = new();
        StringReader reader = new(input);

        Program program = new()
        {
            WriteLine = writer.WriteLine,
            ReadLine = () => reader.ReadLine()!
        };

        // Act
        program.WriteLine("Hello World!");
        string result = program.ReadLine();

        // Assert
        Assert.Equal("Hello World!" + Environment.NewLine, writer.ToString());
        Assert.Equal("Test input", result);
    }

    [Fact]
    public void GetInput_ValidInput_ReturnsInput()
    {
        // Arrange
        StringWriter writer = new();
        StringReader reader = new("Test input");

        Program program = new()
        {
            WriteLine = writer.WriteLine,
            ReadLine = () => reader.ReadLine()!
        };

        // Act
        string result = program.GetInput();

        // Assert
        Assert.Equal("Test input", result);
    }

    [Fact]
    public void PerformCalculation_ValidInput_ReturnsResult()
    {
        // Arrange
        Calculator calculator = new();
        string input = "5 + 5";

        // Act
        double result = Program.PerformCalculation(calculator, input);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void DisplayResult_ValidInput_WritesResult()
    {
        // Arrange
        StringWriter writer = new();
        Program program = new()
        {
            WriteLine = writer.WriteLine
        };

        // Act
        program.DisplayResult(10);

        // Assert
        Assert.Equal("Result: 10" + Environment.NewLine, writer.ToString());
    }

    [Fact]
    public void Run_ValidInput_WritesResult()
    {
        // Arrange
        StringWriter writer = new();
        StringReader reader = new("5 + 5");

        Program program = new()
        {
            WriteLine = writer.WriteLine,
            ReadLine = () => reader.ReadLine()!
        };

        // Act
        program.Run();

        // Assert
        Assert.Equal("Result: 10" + Environment.NewLine, writer.ToString());
    }
}