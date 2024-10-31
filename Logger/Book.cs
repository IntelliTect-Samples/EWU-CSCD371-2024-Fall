namespace Logger;

public record class Book : BaseEntity
{
    // The Name property is implemented implicitly because the IEntity interface defines it,
    // and we override it by returning the books Title.

    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException(nameof(title), "Book title cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null or empty.");
        }

        Title = title;
        Author = author;
    }

    // The Name property is overridden to return the book's Title
    public override string Name => Title;

    // The Id property is inherited from BaseEntity, no need to explicitly define it
}


