namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator<int> calc = new();
        calc.Add(1, 2, out double result);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Subtract_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator<int> calc = new();
        calc.Subtract(3, 2, out double result);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Multiply_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator<int> calc = new();
        calc.Multiply(3, 2, out double result);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Divide_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator<int> calc = new();
        calc.Divide(10, 5, out double result);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowException()
    {
        // Arrange
        Calculator<int> calc = new();

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0, out double result));
    }

    [Fact]
    public void MathematicalOperations_OnConstruct_ShouldContainAllOperations()
    {
        // Assert
        Calculator<int> calc = new();

        // Act and Assert
        Assert.Equal(4, calc.MathematicalOperations.Count);
        Assert.True(calc.MathematicalOperations.ContainsKey('+'));
        Assert.True(calc.MathematicalOperations.ContainsKey('-'));
        Assert.True(calc.MathematicalOperations.ContainsKey('*'));
        Assert.True(calc.MathematicalOperations.ContainsKey('/'));
    }


}