namespace Logger;

public record class Book : BaseEntity
{

    public Book(string title, string authorFirstName, string? authorMiddleName, string authorLastName)
    {
        Title = title;
        Author = new FullName(authorFirstName, authorMiddleName, authorLastName);
    }

    // Is it for internal or external use? implicit / explicit
    // We used explicit implementation for the Name property becuase we need to be able to take Name and parse
    // it into the Title and Author properties. We also need to be able to calculate the Name property from the
    // Title and Author properties.
    override public string Name
    {
        get
        {
            return $"{Title} by: {Author}";
        }
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

            string[] names;
            names = value.Split(":");

            Title = names[0].Substring(0,names[0].Length - 2).Trim();

            string[] authorNames = names[1].Trim().Split(" ");

            if (authorNames.Length == 2)
            {
                Author = new FullName(authorNames[0], authorNames[1]);
            }
            else if (authorNames.Length == 3) 
            {
                Author = new FullName(authorNames[0], authorNames[1], authorNames[2]);
            }
            else
            {
                throw new ArgumentException("Invalid Author Name", names[1]);
            }
        }
    }

    private FullName? _author;

    public FullName Author 
    { 
        get
        {
            return (FullName) _author!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _author = value;
        }
    }

    private string? _title;

    public string Title
    {
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            _title = value;
        }
        get
        {
            return _title!;
        }
    }
}
