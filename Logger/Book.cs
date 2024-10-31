namespace Logger;

public record class Book : BaseEntity
{
    /*
        * Constructor for Book
        Book is Explicitly calling the base class constructor
        It extends the BaseEntity class, and IEntity adding Title, Author, Year, and ISBN.
    */
    public string Title { get; init; }
    public FullName Author { get; init; }
    public int Year { get; init; }
    public string ISBN { get; init; }
    public Book(string title, FullName Author, int year, string isbn)
    {
        this.Author = new FullName(){FirstName = Author.FirstName, MiddleName = Author.MiddleName, LastName = Author.LastName};
        this.Title = title ?? throw new ArgumentNullException(nameof(title));
        this.Year = year; 
        this.ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
    }
     public override string ParseName() => $"{Title} by {Author}, Year: {Year}, ISBN: {ISBN}";
}