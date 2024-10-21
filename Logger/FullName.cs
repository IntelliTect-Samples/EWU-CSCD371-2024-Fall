namespace Logger;

public record FullName
{
    private string _firstName;
    private string _lastName;
    private string _middleName;

    public FullName(string firstName, string lastName, string middleName = "")
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string MiddleName
    {
        get => _middleName;
        set => _middleName = value ?? throw new ArgumentNullException(nameof(value));
    }
}