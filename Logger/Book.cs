namespace Logger;

public record class Book
{
    private string? _isbn;
    private string? _author;
    private int? _publicationYear;
    private string? _title;

    public required string ISBN
    {
        get => _isbn!;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value), $"{nameof(ISBN)} cannot be null or empty.");
            _isbn = value;
        }
    }

    public required string Author
    {
        get => _author!;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value), $"{nameof(Author)} cannot be null or empty.");
            _author = value;
        }
    }

    public required int PublicationYear
    {
        get => _publicationYear ?? throw new InvalidOperationException($"{nameof(PublicationYear)} is not set.");
        init
        {
            if (value <= 0) throw new ArgumentException(nameof(value), $"{nameof(PublicationYear)} must be greater than zero.");
            _publicationYear = value;
        }
    }

    public required string Title
    {
        get => _title!;
        init
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(nameof(value), $"{nameof(Title)} cannot be null or empty.");
            _title = value;
        }
    }
}