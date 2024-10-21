namespace Logger;

public record FullName
{
    private string _firstName;
    private string _lastName;
    private string _middleName;

    public FullName(string firstName, string lastName, string middleName)
    {
        _firstName = firstName;
        _lastName = lastName;
        _middleName = middleName; 
    }

    public string FirstName
    {
        get => _firstName;
        init => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        init => _lastName = value;
    }

    public string MiddleName
    {
        get => _middleName;
        init => _middleName = value;
    }
}