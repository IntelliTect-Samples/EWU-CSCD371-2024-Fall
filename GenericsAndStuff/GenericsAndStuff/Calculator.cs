namespace GenericsAndStuff;

public class Calculator : IParser
{
    public static bool TryParse(string input, out object output)
    {
        output = default;
        return true;
    }
}


public record class Person(string FirstName, string LastName) : IParser
{
    public static bool TryParse(string input, out object output)
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