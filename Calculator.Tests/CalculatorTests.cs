namespace Calculator.Tests;

    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(-1, 1, 0)]
        public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
        {
            var result = Calculates.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(-3, -2, -1)]
        [InlineData(1, -1, 2)]
        public void Subtract_ShouldReturnCorrectDifference(int a, int b, int expected)
        {
            var result = Calculates.Subtract(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, -3, 6)]
        [InlineData(-2, 3, -6)]
        public void Multiply_ShouldReturnCorrectProduct(int a, int b, int expected)
        {
            var result = Calculates.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(-6, -3, 2)]
        [InlineData(-6, 3, -2)]
        public void Divide_ShouldReturnCorrectQuotient(int a, int b, double expected)
        {
            var result = Calculates.Divide(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculates.Divide(1, 0));
        }

        [Theory]
        [InlineData("1 + 2", 3)]
        [InlineData("3 - 2", 1)]
        [InlineData("2 * 3", 6)]
        [InlineData("6 / 3", 2)]
        public void TryCalculate_ShouldReturnTrue_CorrectResult(string expression, double expected)
        {
            var success = Calculates.TryCalculate(expression, out var result);
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 +")]
        [InlineData("a + b")]
        [InlineData("1 ^ 2")]
        public void TryCalculate_ShouldReturnFalse_InvalidExpressions(string expression)
        {
            var success = Calculates.TryCalculate(expression, out var result);
            Assert.False(success);
        }
    }
