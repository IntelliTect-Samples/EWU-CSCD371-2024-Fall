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
}