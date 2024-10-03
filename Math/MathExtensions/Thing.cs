using System.Reflection;

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
        // var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";
        get
        {
            //string.Format("{0} {1}", FirstName, LastName);
            char character = 'a';
            Path.Combine(Assembly.GetExecutingAssembly().Location, "file.txt");
            Path.Combine(Path.GetTempPath(), "file.txt");
            return $"{FirstName} {Environment.NewLine} {LastName}";
        }

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

    private int _age;

    public int Age
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