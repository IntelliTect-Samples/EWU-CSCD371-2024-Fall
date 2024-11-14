namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Program_WriteLine_InvokedCorrectly()
    {
        Program program = new();
        StringWriter writer = new();
        Console.SetOut(writer);

        program.WriteLine("Hello World");

        Assert.AreEqual("Hello World", writer.ToString().Trim());
    }

    [TestMethod]
    public void Program_ReadLine_InvokedCorrectly()
    {
        Program program = new();
        StringReader reader = new("Hello World");
        Console.SetIn(reader);

        string? actual = program.ReadLine();

        Assert.AreEqual("Hello World", actual);
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