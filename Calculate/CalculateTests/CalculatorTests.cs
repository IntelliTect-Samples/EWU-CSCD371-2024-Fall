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
        int sum = Calculator.Add(number1, number2);

        // Assert
        Assert.AreEqual(15, sum);
    }
}