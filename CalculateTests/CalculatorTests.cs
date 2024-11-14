using Calculate;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests

{
    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow((float)1200, 2.5)]
    [DataRow(0.00, 0)]
    public void Add_TwoNumbers_ReturnsSum(double num1, double num2)
    {
        // Arrange

        // Act
        Calculator.Add(num1, num2, out double result);
        // Assert
        Assert.AreEqual(num1 + num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow((float)5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow(1200, 2.5)]
    [DataRow(0.00, 0)]
    public void Subtract_TwoNumbers_ReturnsDifference(double num1, double num2)
    {
        // Arrange

        // Act
        Calculator.Subtract(num1, num2, out double result);

        // Assert
        Assert.AreEqual(num1 - num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow(1200, (float)2.5)]
    [DataRow(0.00, 0)]
    public void Multiply_TwoNumbers_ReturnsProduct(double num1, double num2)
    {
        // Arrange

        // Act
        Calculator.Multiply(num1, num2, out double result);

        // Assert
        Assert.AreEqual(num1 * num2, result);
    }

    [TestMethod]
    [DataRow(5, 10)]
    [DataRow(5.0, 10)]
    [DataRow(0, 0.1)]
    [DataRow((float)1200, (float)2.5)]
    public void Divide_TwoNumbers_ReturnsQuotient(double num1, double num2)
    {
        // Arrange

        // Act
        Calculator.Divide(num1, num2, out double result);

        // Assert
        Assert.AreEqual(num1 / num2, result);
    }

    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.0, 0.0)]
    [DataRow(0, 0.0)]
    [DataRow(1200, 0)]
    public void Divide_ByZero_ThrowsException(double num1, double num2)
    {
        // Arrange

        // Act and Assert
        Assert.ThrowsException<DivideByZeroException>(() => Calculator.Divide(num1, num2, out double result));
    }

    [TestMethod]
    public void MathematicalOperations_OnConstruct_ShouldContainAllOperations()
    {
        var calculator = new Calculator();

        Assert.AreEqual(4, calculator.MathematicalOperations.Count);
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('+'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('-'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('*'));
        Assert.IsTrue(calculator.MathematicalOperations.ContainsKey('/'));
    }

    [TestMethod]
    public void MathematicalOperations_SubtractChar_PointsToProperMethod()
    {
        var calculator = new Calculator();

        //Assert
        Assert.IsTrue(calculator.MathematicalOperations['-'] == Calculator.Subtract);
    }

    [TestMethod]
    public void MathematicalOperations_MultiplyChar_PointsToProperMethod()
    {
        var calculator = new Calculator();

        //Assert
        Assert.IsTrue(calculator.MathematicalOperations['*'] == Calculator.Multiply);
    }

    [TestMethod]
    public void MathematicalOperations_AddChar_PointsToProperMethod()
    {
        var calculator = new Calculator();

        //Assert
        Assert.IsTrue(calculator.MathematicalOperations['+'] == Calculator.Add);
    }

    [TestMethod]
    public void MathematicalOperations_DivideChar_PointsToProperMethod()
    {
        var calculator = new Calculator();

        //Assert
        Assert.IsTrue(calculator.MathematicalOperations['/'] == Calculator.Divide);
    }

    [TestMethod]
    [DataRow("1 + 1", 2, true)]
    [DataRow("12 + 1.1", 13.1, true)]
    [DataRow("1 + 1.1", 2.1, true)]
    [DataRow("12 * 1.1", 13.2, true)]
    [DataRow("121234555 * 0", 0, true)]
    [DataRow("190.12345 * 4.6", 874.56787, true)]
    [DataRow("12 - 12", 0, true)]
    [DataRow("120.1234 - 21.1234", 99, true)]
    [DataRow("12.5 - 100", -87.5, true)]
    [DataRow("12 / 3", 4, true)]
    [DataRow("4.4 / 2.000000", 2.2, true)]
    [DataRow("92.52 / 2.57", 36, true)]
    public void TryCalculate_ValidInput_ReturnsTrue(string input, double expectedResult, bool expectedTryBool)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool wasValid = calculator.TryCalculate(input, out double result);

        // Assert
        Assert.AreEqual(expectedTryBool, wasValid);
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("12/3", double.NaN, false)]
    [DataRow("Hello World", double.NaN, false)]
    public void TryCalculate_InvalidInput_ReturnsFalse(string input, double expectedResult, bool expectedTryBool)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool wasValid = calculator.TryCalculate(input, out double result);

        // Assert
        Assert.AreEqual(expectedTryBool, wasValid);
        Assert.AreEqual(expectedResult, result);
    }
}