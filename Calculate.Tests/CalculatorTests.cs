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
}