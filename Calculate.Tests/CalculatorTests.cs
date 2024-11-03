using Calculate.Core;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_WhenCalled_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 10;
        double expected = 15;

        // Act
        bool success = Calculator.Add(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Subtract_WhenCalled_ReturnsDifference()
    {
        // Arrange
        int a = 10;
        int b = 5;
        double expected = 5;

        // Act
        bool success = Calculator.Subtract(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Multiply_WhenCalled_ReturnsProduct()
    {
        // Arrange
        int a = 5;
        int b = 10;
        double expected = 50;

        // Act
        bool success = Calculator.Multiply(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Theory]
    [InlineData(10, 5)]
    [InlineData(20, 9)]
    [InlineData(30, 7)]
    public void Divide_WhenCalled_ReturnsQuotient(int a, int b)
    {
        // Arrange
        double expected = a / (double)b;

        // Act
        bool success = Calculator.Divide(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Divide_ByZero_Fails()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act
        bool success = Calculator.Divide(a, b, out double actual);

        // Assert
        Assert.Equal(0, actual);
        Assert.False(success);
    }

    [Fact]
    public void MathematicalOperations_OnInstantiation_HasCorrectMappings()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.Equal(Calculator.Add, calculator.MathematicalOperations['+']);
        Assert.Equal(Calculator.Subtract, calculator.MathematicalOperations['-']);
        Assert.Equal(Calculator.Multiply, calculator.MathematicalOperations['*']);
        Assert.Equal(Calculator.Divide, calculator.MathematicalOperations['/']);
    }

    [Theory]
    [InlineData("42 + 42", 84)]
    [InlineData("10 - 5", 5)]
    [InlineData("6 * 7", 42)]
    [InlineData("10 / 2", 5)]
    public void TryCalculate_WhenCalled_ReturnsExpectedResult(string input, double expected)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool success = calculator.TryCalculate(input, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }
}