namespace GenericsAndStuff;

public class Calculator : IParser<int>
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

public record class Person(string FirstName, string LastName) : IParser<Person?>
{
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