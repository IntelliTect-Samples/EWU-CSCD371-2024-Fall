namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator.Add(1, 2, out int result);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Subtract_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator.Subtract(3, 2, out int result);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Multiply_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator.Multiply(3, 2, out int result);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Divide_TwoArguments_ReturnResult()
    {
        // Arrange & Act
        Calculator.Divide(10, 5, out int result);

        // Assert
        Assert.Equal(2, result);
    }


}