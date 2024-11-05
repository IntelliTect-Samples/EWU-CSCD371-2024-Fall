using GenericsAndStuff;

namespace GenericsAndStuffTests;

public class CalculatorTests
{
    [Fact]
    public void Calculator_TryParse_ReturnsCorrectInt()
    {
        bool condition = Calculator.TryParse("1 + 1", out int result);
        Assert.True(condition);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Person_TryParse_ReturnsCorrectPerson()
    {
        bool condition = Person.TryParse("John Doe", out Person? result);
        Assert.True(condition);
        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
    }

    [Fact]
    public void IParserTryParse_SuperTest()
    {

    }
}