namespace Logger;

public record class Book : BaseEntity
{
    public string Title { get; init; }
    public string Author { get; init; }
    public int Year { get; init; }
    public string ISBN { get; init; }

    public override string Name => Title;

    public Book(string title, string author, int year, string isbn)
    {
        this.Title = title;
        this.Author = author;
        this.Year = year;
        this.ISBN = isbn;
    }
    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}