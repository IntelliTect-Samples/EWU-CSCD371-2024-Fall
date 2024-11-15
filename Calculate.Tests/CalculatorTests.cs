namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void TryCalculate_PassedInvalidOperator_ReturnsFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.False(calculator.TryCalculate("2 ( 2", out int res));
    }

    [Fact]
    public void TryCalculate_PassedStringWithNoSpaces_ReturnsFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.False(calculator.TryCalculate("2+2", out int res));
    }

    [Fact]
    public void TryCalculate_PassedTooManyVariables_ReturnsFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.False(calculator.TryCalculate("2 + 2 + 2", out int res));
    }

    [Fact]
    public void TryCalculate_PassedNonIntOperands_ReturnsFalse()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.False(calculator.TryCalculate("d + 2", out int resString));
        Assert.False(calculator.TryCalculate("2.2 + 2", out int resDouble));
    }

    [Fact]
    public void Add_GivenValidInts_ReturnsCorrectAnswer()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.Equal(3, Calculator.Add(1, 2));
    }

    [Fact]
    public void Subtract_GivenValidInts_ReturnsCorrectAnswer()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.Equal(-1, Calculator.Subtract(1, 2));
    }

    [Fact]
    public void Multiply_GivenValidInts_ReturnsCorrectAnswer()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.Equal(2, Calculator.Multiply(1, 2));
    }

    [Fact]
    public void Divide_GivenValidInts_ReturnsCorrectAnswer()
    {
        // Arrange
        Calculator calculator = new();

        // Act

        // Assert
        Assert.Equal(1, Calculator.Divide(2, 2));
    }



    [Theory]
    [InlineData("1 - 1", 0)]
    [InlineData("10 - 5", 5)]
    [InlineData("3 * 4", 12)]
    [InlineData("8 / 2", 4)]
    [InlineData("100 - 50", 50)]
    [InlineData("7 + 3", 10)]
    public void TryCalculate_ValidExpressions_ReturnsExpectedResult(string input, int expected)
    {
        // Arrange
        Calculator calculator = new();

        // Act
        bool result = calculator.TryCalculate(input, out int actual);

        // Assert
        Assert.True(result);
        Assert.Equal(expected, actual);
    }
}