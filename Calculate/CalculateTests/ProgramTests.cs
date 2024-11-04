namespace CalculateTests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void ReadLine_NoInput_ReturnsValidConstructor()
    {
        // Arrange
        Program program = new();
        string simulatedInput = "test";

        // Act
        var stringReader = new StringReader(simulatedInput);

        Console.SetIn(stringReader);
        string testInput = program.ReadLine();

        // Assert
        Assert.IsNotNull(program);
        Assert.AreEqual("test", testInput);
    }

    [TestMethod]
    public void WriteLine_NoInput_ReturnsValidConstructor()
    {
        // Arrange
        Program program = new();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);
        string expectedOutput = "test";

        // Act
        program.WriteLine("test");
        string output = stringWriter.ToString().Trim();

        // Assert
        Assert.AreEqual(expectedOutput, output);
    }
}