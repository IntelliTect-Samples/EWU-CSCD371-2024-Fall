namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Add_LeftAndRight_ReturnsExpected(double left, double right, double expected)
    {
        Assert.Equal(expected, Calculator.Add(left, right));
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(2, 3, -1)]
    [InlineData(-1, 1, -2)]
    [InlineData(0, 0, 0)]
    public void Subtract_LeftAndRight_ReturnsExpected(double left, double right, double expected)
    {
        Assert.Equal(expected, Calculator.Subtract(left, right));
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 3, 6)]
    [InlineData(-1, 1, -1)]
    [InlineData(0, 0, 0)]
    public void Multiply_LeftAndRight_ReturnsExpected(double left, double right, double expected)
    {
        Assert.Equal(expected, Calculator.Multiply(left, right));
    }

    [Theory]
    [InlineData(1, 2, .5)]
    [InlineData(6, 3, 2)]
    [InlineData(-1, 1, -1)]
    [InlineData(-25, -5, 5)]
    public void Divide_LeftAndRight_ReturnsExpected(double left, double right, double expected)
    {
        Assert.Equal(expected, Calculator.Divide(left, right));
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(1, 0));
    }

    [Theory]
    [InlineData("1 + 2", 3)]
    [InlineData("2 - 3", -1)]
    [InlineData("3 * 4", 12)]
    [InlineData("4 / 2", 2)]
    public void TryCalculate_ValidInput_ReturnsExpected(string input, double expected)
    {
        var calculator = new Calculator();
        Assert.True(calculator.TryCalculate(input, out var result));
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1 +2")]
    [InlineData("2- 3")]
    [InlineData("3  * 4")]
    [InlineData("4 /  2")]

    public void TryCalculate_InvalidInput_ReturnsFalse(string input)
    {
        var calculator = new Calculator();
        Assert.False(calculator.TryCalculate(input, out var result));
        Assert.Equal(0.0, result);
    }
}
