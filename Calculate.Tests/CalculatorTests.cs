namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_Adds1And2_Returns3()
    {
        // Arrange
        int a = 1;
        int b = 2;

        // Act
        int actual = Calculator.Add(a, b);

        // Assert
        Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void Subtract_Subtracts1From2_Returns1()
    {
        // Arrange
        int a = 2;
        int b = 1;

        // Act
        int actual = Calculator.Subtract(a, b);

        // Assert
        Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void Multiple_Multiplies2And3_Returns6()
    {
        // Arrange
        int a = 2;
        int b = 3;

        // Act
        int actual = Calculator.Multiple(a, b);

        // Assert
        Assert.AreEqual(6, actual);
    }

    [TestMethod]
    public void Divide_Divides6By3_Returns2()
    {
        // Arrange
        int a = 6;
        int b = 3;

        // Act
        int actual = Calculator.Divide(a, b);

        // Assert
        Assert.AreEqual(2, actual);
    }

    [TestMethod]
    public void Divide_Divides6By0_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 6;
        int b = 0;

        // Act & Assert
        Assert.ThrowsException<DivideByZeroException>(() => Calculator.Divide(a, b));
    }

    [TestMethod]
    [DataRow("1 + 2", 3, true)]
    [DataRow("2 - 1", 1, true)]
    [DataRow("2 * 3", 6, true)]
    [DataRow("6 / 3", 2, true)]
    [DataRow("1 / 0", int.MaxValue, false)]
    [DataRow("1 + 2 + 3", int.MaxValue, false)]
    [DataRow("1+2", int.MaxValue, false)]
    [DataRow("a + b", int.MaxValue, false)]
    public void TryCalculate_TestsDifferentExpressions_ReturnsExpectedResult(string expression, int expectedResult, bool expectedSuccess)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool actualSuccess = calculator.TryCalculate(expression, out int actualResult);

        // Assert
        Assert.AreEqual(expectedSuccess, actualSuccess);
        Assert.AreEqual(expectedResult, actualResult);
    }
}