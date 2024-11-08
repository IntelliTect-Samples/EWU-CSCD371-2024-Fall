using GenericsAndStuff;

namespace GenericsAndStuffTests;

public class CalculatorTests
{
    [Fact]
    public void Calculator_TryParse_ReturnsCorrectInt()
    {
        var calculator = new Calculator();
        void Validate(int result)
        {
            Assert.NotNull(result);
        }
        bool condition = TryParseTrue<CalculatorParser, int>(
            new CalculatorParser(), "1 + 1", out int result, (int result) =>
            {
                Assert.NotNull(result);
                Assert.Equal(2, result);
            });

    }

    [Fact]
    public void Person_TryParse_ReturnsCorrectPerson()
    {
        Action<Person> validate = (Person result) =>
        {
            // Assert.Equal("John", result.FirstName);
            // Assert.Equal("Doe", result.LastName);
        };
        validate(new Person("", ""));

        validate += person => Console.WriteLine(person.LastName);

        validate(new Person("", ""));

        bool condition = TryParseTrue(
            new PersonParser(), "John Doe", out Person result, validate);
    }

    [Fact]
    public void Exception()
    {
        Assert.True(
            Throws<ArgumentNullException>(() => throw new ArgumentNullException()));
    }

    private bool Throws<TException>(Action action)
        where TException : Exception
    {
        try
        {
            action();
            return false;
        }
        catch (TException ex)
        {
            return true;
        }
    }


    [Fact]
    public void MainTest()
    {
        Func<bool> func = () => Main() == 0;
        Assert.True(func());
    }


    [Fact]
    public void Person_NameChanged_EventFires()
    {
        var person = new Person("John", "Doe");
        bool eventFired = false;
        //person.NameChanged += (sender, args) => eventFired = true;
        //person.NameChanged = (sender, args) => eventFired = true;
        person.Name = "Jane";
        Assert.True(eventFired);
    }





    public int Main()
    {
        return 0;
    }

    [Fact]
    public void Delegate()
    {
        //IsValidFunction<int> validate = (int result) =>
        Func<int, bool> validate = (int result) =>
        {
            Assert.NotNull(result);
            Assert.Equal(2, result);
            return true;
        };
    }

    public delegate bool IsValidFunction<T>(T value);

    private bool TryParseTrue<TParser, TOutput>(
        TParser parser, string input, out TOutput output, Action<TOutput> validate)
        where TParser : IParser<TOutput>
    {
        bool condition = parser.TryParse(input, out output);
        Assert.True(condition);
        // Call my validation methods (some assert methods of my choice)
        validate(output);

        return condition;
    }
}