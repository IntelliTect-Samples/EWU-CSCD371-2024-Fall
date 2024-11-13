using System;
using Xunit;
using Calculate;
namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(1 ,2 ,3)]
    [InlineData(10, 5, 15)]
    [InlineData(4, 20, 24)]
    [InlineData(-1, 2, 1)]
    [InlineData(0, 0, 0)]
    public void Add_AddsTwoNumbers_Success(int i, int j, double expected)
    {
        // Act
        double actual = Calculator.Add(i, j);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(15, 5, 10)]
    [InlineData(24, 20, 4)]
    [InlineData(1, 2, -1)]
    [InlineData(0, 0, 0)]
    public void Subtract_SubtractsTwoNumbers_Success(int i, int j, double expected)
    {
        // Act
        double actual = Calculator.Subtract(i, j);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(10, 5, 50)]
    [InlineData(4, 20, 80)]
    [InlineData(-1, 2, -2)]
    [InlineData(0, 0, 0)]
    public void Multiply_MultiplysTwoNumbers_Success(int i, int j, double expected)
    {
        // Act
        double actual = Calculator.Multiply(i, j);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(15, 5, 3)]
    [InlineData(20, 4, 5)]
    [InlineData(-4, 2, -2)]
    public void Divide_DividesTwoNumbers_Success(int i, int j, double expected)
    {
        // Act
        double actual = Calculator.Divide(i, j);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_DivideByZero_DivideByZeroExecption() 
    {
        //arrange
        int i = 5; int j = 0;
        //act & assert
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(i, j));

    }

    [Theory]
    [InlineData("1 + 2", 3)]
    [InlineData("1 - 2", -1)]
    [InlineData("1 * 2", 2)]
    [InlineData("1 / 2", 0.5)]
    public void TryCalculate_ValidInput_ReturnsExepected(string equation, double expected)
    {
        var calculator = new Calculator();
        Assert.True(calculator.TryCalculate(equation, out var result));
        Assert.Equal(expected, result);

    }

    [Theory]
    [InlineData("1 +2")]
    [InlineData("1- 2")]
    [InlineData("1 *  2")]
    [InlineData("1  / 2")]
    [InlineData("3 + 2 + 1")]
    [InlineData("1 - II")]
    [InlineData("I - 2")]
    [InlineData("1  divided 2")]
    public void TryCalculate_InValidInput_ReturnsFalse(string equation)
    {
        var calculator = new Calculator();
        Assert.False(calculator.TryCalculate(equation, out var result));
        Assert.Equal(0.0, result);


    }



}
