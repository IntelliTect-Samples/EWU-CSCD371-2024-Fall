using System;
namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_AddsTwoNumbers_Success()
    {
        // Arrange
        int a = 5;
        int b = 10;
        int expected = 15;

        // Act
        int actual = Calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Subtract_SubtractsTwoNumbers_Success()
    {
        // Arrange
        int a = 10;
        int b = 5;
        int expected = 5;

        // Act
        int actual = Calculator.Subtract(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Multiplication_MultipliesTwoNumbers_Success()
    {
        // Arrange
        int a = 5;
        int b = 10;
        int expected = 50;

        // Act
        int actual = Calculator.Multiplication(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Division_DividesTwoNumbers_Success()
    {
        // Arrange
        int a = 10;
        int b = 5;
        int expected = 2;

        // Act
        int actual = Calculator.Division(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Division_DividesByZero_ThrowsException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act and Assert
        Assert.Throws<DivideByZeroException>(() => Calculator.Division(a, b));
    }

    [Fact]
    public void TryCalculate_AddsTwoNumbers_Success()
    {
        // Arrange
        Calculator cal = new();
        string expression = "5 + 10";
        int expected = 15;

        // Act
        bool actual = cal.TryCalculate(expression, out int? result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_SubtractsTwoNumbers_Success()
    {
        // Arrange
        Calculator cal = new();
        string expression = "10 - 5";
        int expected = 5;

        // Act
        bool actual = cal.TryCalculate(expression, out int? result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_MultipliesTwoNumbers_Success()
    {
        // Arrange
        Calculator cal = new();
        string expression = "5 * 10";
        int expected = 50;

        // Act
        bool actual = cal.TryCalculate(expression, out int? result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_DividesTwoNumbers_Success()
    {
        // Arrange
        Calculator cal = new();
        string expression = "10 / 5";
        int expected = 2;

        // Act
        bool actual = cal.TryCalculate(expression, out int? result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_DividesByZero_Failure()
    {
        // Arrange
        Calculator cal = new();
        string expression = "10 / 0";

        // Act and Assert
        Assert.Throws<DivideByZeroException>(() => cal.TryCalculate(expression, out int? result));
    }

    [Fact]
    public void TryCalculate_InvalidExpression_Failure()
    {
        // Arrange
        Calculator cal = new();
        string expression = "10 5";

        // Act
        bool actual = cal.TryCalculate(expression, out int? result);

        // Assert
        Assert.False(actual);
        Assert.Null(result);
    }

    [Fact]
    public void TryCalculate_NotEnoughArgs_Failure()
    {
        // Arrange
        Calculator cal = new();
        string expression = "10 * ";

        // Act and Assert
        Assert.False(cal.TryCalculate(expression, out int? result));
    }
}
