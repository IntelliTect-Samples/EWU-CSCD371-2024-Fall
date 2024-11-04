namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        Calculator calculator = new();
        int number1 = 5;
        int number2 = 10;

        // Act
        int sum = calculator.Add(number1, number2);

        // Assert
        Assert.AreEqual(15, sum);
    }
}