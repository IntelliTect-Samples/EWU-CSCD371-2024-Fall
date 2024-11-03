namespace Calculate.Tests;

public class ProgramTests
{
    [Theory]
    [InlineData("Test input")]
    public void Constructor_Properties_InvokesProperties(string input)
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
}