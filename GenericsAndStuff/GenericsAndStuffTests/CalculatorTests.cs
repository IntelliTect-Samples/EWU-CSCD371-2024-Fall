using GenericsAndStuff;

namespace GenericsAndStuffTests;

public class CalculatorTests
{
    [Fact]
    public void Calculator_TryParse_ReturnsCorrectInt()
    {
        bool condition = Calculator.TryParse("1 + 1", out object result);
        Assert.True(condition);
        if (result is int value)
        {
            Assert.Equal(2, value);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void Person_TryParse_ReturnsCorrectPerson()
    {
        bool condition = Person.TryParse("John Doe", out object result);
        Assert.True(condition);
        if (result is Person person)
        {
            Assert.Equal("John", person.FirstName);
            Assert.Equal("Doe", person.LastName);
        }
        else
        {
            Assert.Fail();
        }
    }
}