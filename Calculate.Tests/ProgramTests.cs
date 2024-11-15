namespace Calculate.Tests;

public class ProgramTests
{
    private string Output = "";
    private const string Input = "Testing";

    [Fact]
    public void Program_WriteLine_InvokesCorrectly()
    {
        // Arrange
        var program = new Program(
            writeLine: text => Output = text,
            readLine: () => Input
        );

        // Act
        program.WriteLine("Howdy");

        // Assert
        Assert.Equal("Howdy", Output);
    }

    [Fact]
    public void Program_ReadLine_InvokesCorrectly()
    {
        // Arrange
        var program = new Program(
            writeLine: text => Output = text,
            readLine: () => Input
        );

        // Act
        var readResult = program.ReadLine();

        // Assert
        Assert.Equal(Input, readResult);
    }

    [Fact]
    public void TryCalculate_GivenDivideByZero_CatchesAndOutputsCorrectly()
    {
        // Arrange
        StringWriter writer = new();
        Console.SetOut(writer);

        StringReader reader = new($"2 / 0{Environment.NewLine}EXIT{Environment.NewLine}");
        Console.SetIn(reader);
        // Act
        Program program = new(Console.WriteLine, Console.ReadLine);
        Program.Main();

        // Assert
        Assert.Equal("Welcome to ultimate calculator.\nEnsure format: 'int validOperator int'\nType EXIT to close the program.\r\nIt's not possible to divide by zero, please try again\r\n", writer.ToString());
    }
}

