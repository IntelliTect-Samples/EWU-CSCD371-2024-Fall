namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_WriteLineAndReadLine_InitAtConstructor()
    {
        // Arrange
        string expectedOutput = "Kill ME NOW!!!";
        string capturedOutput = string.Empty;
        
        Program program = new()
        {
            Writeline = (output) => capturedOutput = output,
            Readline = () => expectedOutput
        };
        
        
        // Act
        program.Writeline(expectedOutput);
        string readResult = program.Readline();
        
        // Assert
        Assert.Equal(expectedOutput, capturedOutput);
        Assert.Equal(expectedOutput, readResult);
    }
    
    [Fact]
    public void Main_InitializesProgramCorrectly()
    {
        // Arrange
        Program program = new ();

        // Act & Assert
        Assert.NotNull(program.Writeline);
        Assert.NotNull(program.Readline);
    }
   
    [Fact]
    public void Program_Writeline_WritesExpectedOutputToConsole()
    {
        // Arrange
        string expectedOutput = "Please Kill Me Now!!!";
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Initialize Program with Writeline set to Console.WriteLine
        Program program = new()
        {
            Writeline = Console.WriteLine
        };

        // Act
        program.Writeline(expectedOutput);

        // Reset Console output after the test
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

        // Assert
        string result = sw.ToString().Trim();
        Assert.Equal(expectedOutput, result);
    }
    
    [Fact]
    public void Program_Readline_ReadsExpectedInputFromConsole()
    {
        // Arrange
        string expectedInput = " You know nothing Jon Snow!";
        using var sr = new StringReader(expectedInput);
        Console.SetIn(sr);

        // Initialize Program with Readline set to Console.ReadLine with null-coalescing operator
        Program program = new()
        {
            Readline = () => Console.ReadLine() ?? ""
        };

        // Act
        string result = program.Readline();

        // Reset Console input after the test
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));

        // Assert
        Assert.Equal(expectedInput, result);
    }

    [Fact]
    public void Run_ValidExpression_ReturnsCorrectResult()
    {
        // Arrange
        string inputExpression = "2 + 2";
        string expectedOutput = "Result: 4";
        string capturedOutput = string.Empty;

        // Create a sequence of inputs to simulate user interaction
        Queue<string> inputs = new Queue<string>(new[] { inputExpression, "no" });

        ProgramTestable program = new()
        {
            Writeline = (output) => capturedOutput += output,
            Readline = () => inputs.Dequeue()
        };

        // Act
        program.RunPublic();

        // Assert
        Assert.Contains(expectedOutput, capturedOutput);
        Assert.Contains("Goodbye!", capturedOutput);
    }

}

public class ProgramTestable : Program
{
    public void RunPublic() => Run(); // Expose Run as a public method for testing
}
