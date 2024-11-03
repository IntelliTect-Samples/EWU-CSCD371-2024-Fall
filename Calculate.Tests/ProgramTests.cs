namespace Calculate.Tests;

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
}