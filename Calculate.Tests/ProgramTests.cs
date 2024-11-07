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
}