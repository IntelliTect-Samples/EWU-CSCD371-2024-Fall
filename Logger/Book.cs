namespace Logger;

public record Book : BaseEntity
{
    private string? _title;
    private string? _isbn;

    public Book(FullName author, string title, string isbn)
    {
        Author = author;
        Title = title;
        ISBN = isbn;
    }

    public FullName Author { get; set; }

    public string Title 
    {
        get => _title!;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, "Title cannot be null or empty");
            _title = value;
        }
    }

    public string ISBN
    {
        get => _isbn!;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, "ISBN cannot be null or empty");
            _isbn = value;
        }
    }

    // This is an explicit implementation to allow for unique formatting of the name.
    public override string Name => $"{Title} written by {Author}. ISBN: {ISBN}";
}
