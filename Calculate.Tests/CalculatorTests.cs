namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoArguments_ReturnParameter()
    {
        // Arrange & Act
        Calculator.Add(1, 2, out int result);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Subtract_TwoArguments_ReturnParameter()
    {
        // Arrange & Act
        Calculator.Subtract(3, 2, out int result);

        // Assert
        Assert.Equal(1, result);
    }
}