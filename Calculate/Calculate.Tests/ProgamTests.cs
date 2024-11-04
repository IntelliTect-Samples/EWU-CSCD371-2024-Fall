using System.Security.Cryptography.X509Certificates;

namespace Calculate.Tests;

public class ProgamTests
{
    [Fact]
    public void SetAndInvokeProperties_BehavesAsExpected_Success()
    {
        // Arrange
        var writer = new StringWriter();
        void newWriteLine(string input)
        {
            Console.SetOut(writer);
            Console.WriteLine(input.Trim());
        }
        string? newReadLine()
        {
            return "whatever";
        }
        var program = new Program(newWriteLine, newReadLine);

        // Act
        program.WriteLine("    whatever        ");
        // Assert
        Assert.Equal("whatever", program.ReadLine());
        Assert.Equal("whatever", writer.ToString());
    }
}