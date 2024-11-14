﻿using System;
namespace Calculate.Tests;

public class CalculatorTests
{
    private readonly Calculator<double> _calculator = new();

    [Fact]
    public void Add_AddsTwoNumbers_Success()
    {
        // Arrange
        int a = 5;
        int b = 10;
        int expected = 15;

        // Act
        double actual = _calculator.Add(a, b);

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
        double actual = _calculator.Subtract(a, b);

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
        double actual = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Division_DividesTwoNumbers_Success()
    {
        // Arrange
        int a = 7;
        int b = 2;
        double expected = 3.5;

        // Act
        double actual = _calculator.Divide(a, b);

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
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void TryCalculate_AddsTwoNumbers_Success()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "5 + 10";
        int expected = 15;

        // Act
        bool actual = cal.TryCalculate(expression, out double result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_SubtractsTwoNumbers_Success()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "10 - 5";
        int expected = 5;

        // Act
        bool actual = cal.TryCalculate(expression, out double result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_MultipliesTwoNumbers_Success()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "5 * 10";
        int expected = 50;

        // Act
        bool actual = cal.TryCalculate(expression, out double result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_DividesTwoNumbers_Success()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "7 / 2";
        double expected = 3.5;

        // Act
        bool actual = cal.TryCalculate(expression, out double result);

        // Assert
        Assert.True(actual);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_DividesByZero_Failure()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "10 / 0";

        // Act and Assert
        Assert.Throws<DivideByZeroException>(() => cal.TryCalculate(expression, out double result));
    }

    [Fact]
    public void TryCalculate_InvalidExpression_Failure()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "10 5";

        // Act
        bool actual = cal.TryCalculate(expression, out double result);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void TryCalculate_NotEnoughArgs_Failure()
    {
        // Arrange
        Calculator<double> cal = new();
        string expression = "10 * ";

        // Act and Assert
        Assert.False(cal.TryCalculate(expression, out double result));
    }
}
