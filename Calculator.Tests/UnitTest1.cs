using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Calculate.Tests;

public class UnitTest1
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

        // Assert
    }
}