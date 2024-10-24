namespace Logger;
public record class Employee : Person
{
    public string Position { get; set; }
    public Employee(string id, string position, string first, string last, string? middle = null) : base(first, last, id, middle)
    {
        Position = position ?? throw new ArgumentNullException(nameof(position), $"{nameof(position)} was null");
    }
}