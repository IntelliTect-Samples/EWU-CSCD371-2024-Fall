namespace Calculate.Tests;

public class ProgramTests
{
    private static string _output = string.Empty;
    private static string TestInput() => "42 / 2";
    private static void TestOutput(string value) => _output = value;

    [Fact]
    public void Main_ChangeInput_Success()
    {
        // Arrange
        int? answer;
        Program program = new()
        {
            ReadLine = TestInput
        };
        Calculator calculator = new();

        // Act
        string? input = program.ReadLine();
        calculator.TryCalculate(input!, out answer);

        // Assert
        Assert.Equal(21, answer);
    }

    [Fact]
    public void Main_ChangeOutput_Success()
    {
        // Arrange
        Program program = new()
        {
            WriteLine = TestOutput
        };

        // Act
        program.WriteLine("Yes");

        // Assert
        Assert.Equal("Yes", _output);

        _output = string.Empty;
    }

    [Fact]
    public void Program_WriteLineAndReadLine_Success()
    {
        // Arrange
        string expected = "Hello world!";
        string actual = string.Empty;
        Program program = new()
        {
            WriteLine = (s) => actual = s,
            ReadLine = () => expected
        };

        // Act
        program.WriteLine(expected);

        // Assert
        Assert.Equal(expected, actual);
    }


}
