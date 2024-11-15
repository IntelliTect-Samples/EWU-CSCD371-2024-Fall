namespace Calculator.Tests;

    public class CalculatorTests
    {
        [Fact]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int a = 10;
            int b = 5;
            double expected = 5;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_TwoNegativeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int a = -10;
            int b = -5;
            double expected = -5;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_PositiveAndNegativeNumber_ReturnsCorrectResult()
        {
            // Arrange
            int a = 10;
            int b = -5;
            double expected = 15;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_NegativeAndPositiveNumber_ReturnsCorrectResult()
        {
            // Arrange
            int a = -10;
            int b = 5;
            double expected = -15;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_ZeroAndNumber_ReturnsCorrectResult()
        {
            // Arrange
            int a = 0;
            int b = 5;
            double expected = -5;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_NumberAndZero_ReturnsCorrectResult()
        {
            // Arrange
            int a = 5;
            int b = 0;
            double expected = 5;
            double result;

            // Act
            bool success = Calculates.Subtract(a, b, out result);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, result);
        }
    }
