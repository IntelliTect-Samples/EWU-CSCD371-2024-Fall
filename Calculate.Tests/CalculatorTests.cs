namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoArguments_ReturnParameter()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        int result = calculator.Add(1, 2);

        // Assert
        Assert.Equal(3, result);
    }
}