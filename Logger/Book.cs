namespace Logger;
// TODO: Comments on each member explaining implicit or explicit implementation

public record class Book() : BaseEntity
{
    // Is it for internal or external use? implicit / explicit
    // Explicit
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
