namespace GenericsAndStuff;

public class Calculator : IStringParser<int>
{
    public static bool TryParse(string input, out int output)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            output = default;
            return false;
        }

        output = 2;
        return true;
    }
}

public class CalculatorParser : IParser<int>
{

    public bool TryParse(string input, out int output)
    {
        return Calculator.TryParse(input, out output);
    }
}

public class PersonParser : IParser<Person>
{
    public bool TryParse(string input, out Person? output)
    {
        return Person.TryParse(input, out output);
    }
}

public record class Person(string FirstName, string LastName) : IStringParser<Person?>
{
    private string name = $"{FirstName} {LastName}";

    public string Name
    {
        get
        {
            return name;
        }
        set
        {

            name = value;
            NameChanged?.Invoke(this, new());
        }
    }
    public event EventHandler<EventArgs> NameChanged;

    public static bool TryParse(string input, out Person? output)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            output = default;
            return false;
        }

        if (input.Split(' ').Length != 2)
        {
            output = default;
            return false;
        }
        else
        {
            var parts = input.Split(' ');
            output = new Person(parts[0], parts[1]);
            return true;
        }
    }
}