namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void WriteLine_WritesToConsole_Success()
    {
        // Arrange
        Program program = new();
        string message = "Hello, World!";
        StringWriter writer = new();
        Console.SetOut(writer);

        // Act
        program.WriteLine(message);

        // Assert
        Assert.AreEqual(message, writer.ToString().Trim());
    }

    [TestMethod]
    public void ReadLine_ReadsInputFromConsole_Success()
    {
        // Arrange
        Program program = new();
        string input = "Hello, World!";
        StringReader reader = new(input);
        Console.SetIn(reader);

        // Act and Assert
        Assert.AreEqual(input, program.ReadLine());
    }

    [TestMethod]
    public void Main_CalculatesExpression_Success()
    {
        StringWriter writer = new();
        Console.SetOut(writer);
        StringReader reader = new($"2 + 3{Environment.NewLine}");
        Console.SetIn(reader);

        Program.Main([]);

        Assert.AreEqual($"Enter an expression to calculate:{Environment.NewLine}Result: 5", writer.ToString().Trim());
    }
}