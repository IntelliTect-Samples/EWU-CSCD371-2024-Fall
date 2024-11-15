using Moq;
using Calculator;
namespace Calculator.Tests;
public class ProgramTest
{
    [Fact]
    public void Main_ValidExpression_PrintsResult()
    {
        // Arrange
        var input = "3 + 4";
        var expectedOutput = "Enter a mathematical expression (e.g., 3 + 4):"+Environment.NewLine+"Result: 7"+Environment.NewLine;
        var stringReader = new StringReader(input);
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Program.Main();

        // Assert
        var output = stringWriter.ToString();
        Assert.Equal(expectedOutput, output);
    }

}
    

