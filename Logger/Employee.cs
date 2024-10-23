namespace Logger;
public record class Employee (string id, string position, string first, string last, string? middle = null) : Person(first, last, id, middle)
{
    public string Position = position ?? throw new ArgumentNullException(nameof(position), $"{nameof(position)} was null");
}