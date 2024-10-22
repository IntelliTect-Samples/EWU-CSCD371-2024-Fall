namespace Logger;

public record class FullName
{
    private string? _firstName;
    private string? _lastName;
    private string? _middleName;

    public FullName(string firstName, string lastName, string middleName = "")
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public string FirstName
    {
        get => _firstName!;
        set => _firstName = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value))
            : value;
    }

    public string LastName
    {
        get => _lastName!;
        set => _lastName = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value))
            : value;
    }

    public string MiddleName
    {
        get => _middleName!;
        set => _middleName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString() => MiddleName switch
    {
        "" => $"{FirstName} {LastName}",
        _ => $"{FirstName} {MiddleName} {LastName}"
    };
}