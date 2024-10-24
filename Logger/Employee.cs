namespace Logger;

public record class Employee(FullName NameDetails, string Position) : Person(NameDetails)
{
    private string _position = Position ?? throw new ArgumentNullException(nameof(Position), "Position cannot be null.");

    public string Position
    {
        get => _position;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Position cannot be null or whitespace.", nameof(value));
            }
            _position = value;
        }
    }
}