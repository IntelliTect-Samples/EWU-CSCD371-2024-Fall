namespace Logger;

public abstract record class Person : BaseEntity
{
    // The only common code shared between Student and Employee is their full name.

    private FullName? _personName;

    protected Person(string firstName, string? middleName, string lastName)
    {
        PersonName = new FullName(firstName, middleName, lastName);
    }

    public FullName PersonName
    {
        get
        {
            return (FullName)_personName!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _personName = value;
        }
    }

}