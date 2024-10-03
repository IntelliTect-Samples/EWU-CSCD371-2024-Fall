namespace MathExtensions;

public class Thing
{
    public Thing()
    {
        Age = 0;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Name
    {
        get => FirstName + " " + LastName;
        set
        {
            string[] names = value.Split(' ');
            if (names.Length == 2)
            {
                FirstName = names[0];
                LastName = names[1];
            }
            else
            {
                throw new ArgumentException("Name must contain a first and last name.");
            }
        }
    }

    private float _age;

    public float Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            _age = value;
        }
    }
}