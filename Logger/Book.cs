namespace Logger;

public record class Book : BaseEntity
{
    public string Title { get; init; }
    public FullName Author { get; init; }
    public int Year { get; init; }
    public string ISBN { get; init; }
    public Book(string title, FullName Author, int year, string isbn)
    {
        this.Author = new FullName(){FirstName = Author.FirstName, MiddleName = Author.MiddleName, LastName = Author.LastName};
        this.Title = title;
        this.Year = year;
        this.ISBN = isbn;
    }
     public override string ParseName() => $"{Title} by {Author}, Year: {Year}, ISBN: {ISBN}";
}