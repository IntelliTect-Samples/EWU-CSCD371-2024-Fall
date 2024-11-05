using Calculate;

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
        string? testInput = program.ReadLine();

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

    [TestMethod]
    public void Run_ValidInputs_ReturnsExpectedResults()
    {
        //Arrange
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);
        StringReader reader = new($"12 + 2{Environment.NewLine}2 - 2{Environment.NewLine}2.0 * 16.6{Environment.NewLine}12-2{Environment.NewLine}hi there{Environment.NewLine} 2/2{Environment.NewLine}exit");
        String expectedResult =$"Please type a simple mathematical equation or type exit{Environment.NewLine}14{Environment.NewLine}0{Environment.NewLine}33.2{Environment.NewLine}Invalid string. Please follow format of '# operator #'{Environment.NewLine}Invalid string. Please follow format of '# operator #'{Environment.NewLine}Invalid string. Please follow format of '# operator #'{Environment.NewLine}".Trim();
        Console.SetIn(reader);
        Program program = new(Console.ReadLine,Console.WriteLine);
        //Act
        program.Run();
                

        //Assert
        Assert.AreEqual(expectedResult, writer.ToString().Trim());
    }
}