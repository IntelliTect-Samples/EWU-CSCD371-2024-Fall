using Calculate.Core;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_WhenCalled_ReturnsSum()
    {
        // Arrange
        Calculator<int> calculator = new();
        int a = 5;
        int b = 10;
        double expected = 15;

        // Act
        bool success = calculator.Add(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Subtract_WhenCalled_ReturnsDifference()
    {
        // Arrange
        Calculator<int> calculator = new();
        int a = 10;
        int b = 5;
        double expected = 5;

        // Act
        bool success = calculator.Subtract(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Multiply_WhenCalled_ReturnsProduct()
    {
        // Arrange
        Calculator<int> calculator = new();
        int a = 5;
        int b = 10;
        double expected = 50;

        // Act
        bool success = calculator.Multiply(a, b, out double actual);

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
        Calculator<double> calculator = new();
        double expected = a / (double)b;

        // Act
        bool success = calculator.Divide(a, b, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void Divide_ByZero_Fails()
    {
        // Arrange
        Calculator<double> calculator = new();
        int a = 10;
        int b = 0;

        // Act
        bool success = calculator.Divide(a, b, out double actual);

        // Assert
        Assert.Equal(0, actual);
        Assert.False(success);
    }

    [Fact]
    public void MathematicalOperations_OnInstantiation_HasCorrectMappings()
    {
        // Arrange
        Calculator<int> calculator = new();

        // Act

        // Assert
        Assert.Equal(calculator.Add, calculator.MathematicalOperations['+']);
        Assert.Equal(calculator.Subtract, calculator.MathematicalOperations['-']);
        Assert.Equal(calculator.Multiply, calculator.MathematicalOperations['*']);
        Assert.Equal(calculator.Divide, calculator.MathematicalOperations['/']);
    }

    [Theory]
    [InlineData("42 + 42", 84)]
    [InlineData("10 - 5", 5)]
    [InlineData("6 * 7", 42)]
    [InlineData("10 / 2", 5)]
    public void TryCalculate_ValidString_ReturnsExpectedResult(string input, double expected)
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate(input, out double actual);

        // Assert
        Assert.Equal(expected, actual);
        Assert.True(success);
    }

    [Fact]
    public void TryCalculate_NumberAndOperator_ReturnsFalse()
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate("42 * ", out double actual);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void TryCalculate_OnlyOperator_ReturnsFalse()
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate(" * ", out double actual);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void TryCalculate_InvalidOperator_ReturnsFalse()
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate("42 % 42", out double actual);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void TryCalculate_InvalidOperands_ReturnsFalse()
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate("42 + forty-two", out double actual);

        // Assert
        Assert.False(success);
    }

    [Fact]
    public void TryCalculate_InvalidString_ReturnsFalse()
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryCalculate("42 + 42 + 42", out double actual);

        // Assert
        Assert.False(success);
    }
}