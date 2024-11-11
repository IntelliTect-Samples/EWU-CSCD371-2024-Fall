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

    [Fact]
    public void MathematicalOperations_AddChar_PointsToAddMethod()
    {
        // Arrange
        Calculator<int> calc = new();

        // Act
        var addOperation = calc.MathematicalOperations['+'];
        double result = addOperation(1, 2);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void MathematicalOperations_SubtractChar_PointsToSubtractMethod()
    {
        // Arrange
        Calculator<int> calc = new();

        // Act
        var subtractOperation = calc.MathematicalOperations['-'];
        double result = subtractOperation(3, 2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MathematicalOperations_MultiplyChar_PointsToMultiplyMethod()
    {
        // Arrange
        Calculator<int> calc = new();

        // Act
        var multiplyOperation = calc.MathematicalOperations['*'];
        double result = multiplyOperation(3, 2);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void MathematicalOperations_DivideChar_PointsToDivideMethod()
    {
        // Arrange
        Calculator<int> calc = new();

        // Act
        var divideOperation = calc.MathematicalOperations['/'];
        double result = divideOperation(10, 2);

        // Assert
        Assert.Equal(5, result);
    }

    [Theory]
    [InlineData("1 + 3", 4, true)]
    [InlineData("1 + 2.1", 3.1, true)]
    [InlineData("8888 * 1", 8888, true)]
    [InlineData("33.55 * 7.77", 260.6835, true)]
    [InlineData("1 - 1", 0, true)]
    [InlineData("6.6 / 3.00", 2.2, true)]
    public void TryCalculate_ValidString_ParsesResult(string input, double expected, bool boolResult)
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool valid = calculator.TryCalculate(input, out double result);

        // Assert
        Assert.Equal(boolResult, valid);
        Assert.Equal(expected, result, precision: 5);
    }

    [Theory]
    [InlineData("123", 123, true)]
    [InlineData("456.78", 456.78, true)]
    [InlineData("3.14159", 3.14159, true)]
    [InlineData("-99.99", -99.99, true)]
    [InlineData("notANumber", 0, false)]
    [InlineData("", 0, false)]
    public void TryParse_WithVariousInputs_ReturnsExpectedResults(string input, double expectedValue, bool expectedSuccess)
    {
        // Arrange
        Calculator<double> calculator = new();

        // Act
        bool success = calculator.TryParse(input, out double result);

        // Assert
        Assert.Equal(expectedSuccess, success);
        Assert.Equal(expectedValue, result, precision: 5);
    }

}