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
    public void Main_GivenDivideByZeroInput_CatchesAndOutputsCorrectly()
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
        Assert.Equal($"Welcome to ultimate calculator.{Environment.NewLine}Ensure format: 'int validOperator int'" +
            $"{Environment.NewLine}Type EXIT to close the program.{Environment.NewLine}It's not possible to divide by zero, please try again" +
            $"{Environment.NewLine}", writer.ToString());
    }

    [Fact]
    public void Main_GivenValidInput_OutputsResult()
    {
        // Arrange
        StringWriter writer = new();
        Console.SetOut(writer);

        StringReader reader = new($"2 / 2{Environment.NewLine}EXIT{Environment.NewLine}");
        Console.SetIn(reader);
        // Act
        Program program = new(Console.WriteLine, Console.ReadLine);
        Program.Main();

        // Assert
        Assert.Equal($"Welcome to ultimate calculator.{Environment.NewLine}Ensure format: 'int validOperator int'" +
            $"{Environment.NewLine}Type EXIT to close the program.{Environment.NewLine}Result: 1{Environment.NewLine}", writer.ToString());
    }

    [Fact]
    public void Main_GivenStringNoSpacesInput_OutputsInvalidInputMessage()
    {
        // Arrange
        StringWriter writer = new();
        Console.SetOut(writer);

        StringReader reader = new($"2/2{Environment.NewLine}EXIT{Environment.NewLine}");
        Console.SetIn(reader);
        // Act
        Program program = new(Console.WriteLine, Console.ReadLine);
        Program.Main();

        // Assert
        Assert.Equal($"Welcome to ultimate calculator.{Environment.NewLine}Ensure format: 'int validOperator int'" +
            $"{Environment.NewLine}Type EXIT to close the program.{Environment.NewLine}Invalid input string. Ensure format: 'int validOperator int'" +
            $"{Environment.NewLine}", writer.ToString());
    }
}

