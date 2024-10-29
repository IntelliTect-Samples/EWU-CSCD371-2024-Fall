namespace Logger;

public record class Book : Entity
{
    public string Title { get; init; }
    public string Author { get; init; }

    // Name is implemented implicitly because the book requires a specific format of it
    public override string Name => $"{Title} by {Author}";

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}
