namespace Logger;

public record class Book : Entity
{
    public FullName Author { get; set; }
    public string Isbn { get; init; }
    public int PublicationYear { get; init; }
    public string Title { get; init; }

    public Book(string isbn, int publicationYear, string title, string first, string last, string? middle = null)
    {
        Author = new() { First = first, Last = last, Middle = middle };
        Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn), $"{nameof(isbn)} was null.");
        if (publicationYear <= 0)
            throw new ArgumentException(nameof(publicationYear), $"{nameof(publicationYear)} must be greater than zero.");
        PublicationYear = publicationYear;
        Title = title ?? throw new ArgumentNullException(nameof(title), $"{nameof(title)} was null.");
    }

    protected override string ParseName()
    {
        return $"{Title} by {Author}, year: {PublicationYear}, ISBN: {Isbn}";
    }
}