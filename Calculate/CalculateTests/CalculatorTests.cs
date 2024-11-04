using Calculate;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        int number1 = 5;
        int number2 = 10;

        // Act
        Calculator.Add(number1, number2, out int result);

        // Assert
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        // Arrange
        int num1 = 10;
        int num2 = 5;

        // Act
        Calculator.Subtract(num1, num2, out int result);

        // Assert
        Assert.AreEqual(5, result);
    }
}