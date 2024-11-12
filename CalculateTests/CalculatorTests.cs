using Xunit;
using Calculate;

namespace CalculateTests;

public class CalculatorTests
{
    [Theory]
    [InlineData("3 + 4", 7, true)]
    [InlineData("42 - 2", 40, true)]
    [InlineData("10 * 5", 50, true)]
    [InlineData("50 / 2", 25, true)]
    [InlineData("3+4", 0, false)]
    [InlineData("10 / 0", 0, false)]
    [InlineData("abc + 2", 0, false)]
    public void TryCalculate_TestsAllOperations_ReturnsExpectedResult(string input, int expectedResult, bool expectedSuccess)
    {
        // Act
        bool success = Calculator.TryCalculate(input, out int result);

        // Assert
        Assert.Equal(expectedSuccess, success);
        if (expectedSuccess)
        {
            Assert.Equal(expectedResult, result);
        }
    }
}
