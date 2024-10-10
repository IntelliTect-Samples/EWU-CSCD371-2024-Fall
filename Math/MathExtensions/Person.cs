namespace MathExtensions;

public class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetName(string name)
    {
        //FirstName = firstName;
    }


    private string? _lastName;

    public string LastName
    {
        get
        {
            return _lastName!;
        }
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            _lastName = value;
        }
    }

    private Person? _spouse;

    public Person Spouse
    {
        get => _spouse!;
        set => _spouse = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string? _firstName;

    public string FirstName
    {
        get
        {
            return _firstName!;
        }
        set
        {
            //ArgumentNullException.ThrowIfNull(value);
            //ArgumentNullException.ThrowIfNullOrEmpty(value);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            _firstName = value;
        }
    }

    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }
}