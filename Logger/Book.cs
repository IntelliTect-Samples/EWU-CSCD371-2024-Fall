using System.Reflection;

namespace Logger;
public record class Book : BaseEntity
{
public string Title { get; init;}
public FullName Author { get; set;}
public int YearPublished { get; init;}
public int Isbn { get; init; }

    // Not sure if Name should be Title here, or Author's name. Will inquire.
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

public Book(string title, string authorName, int? yearPublished, int? isbn)
{
Title = title ?? throw new ArgumentNullException(nameof(title), $"{nameof(title)} was null.");

Author = ParseAuthor(authorName);
//Author = author; We need to parse this to a FullName object.
YearPublished = yearPublished ?? throw new ArgumentNullException(nameof(yearPublished), $"{nameof(yearPublished)} was null.");
Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn), $"{nameof(isbn)} was null.");
}

private static FullName ParseAuthor(string authorName)
{
if (string.IsNullOrWhiteSpace(authorName))
{
throw new ArgumentNullException(nameof(authorName), "Author name cannot be null or whitespace.");
}

// Split the name by spaces
var nameParts = authorName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

return nameParts.Length switch
{
2 => new FullName(nameParts[0], null, nameParts[1]),               // "First Last"
3 => new FullName(nameParts[0], nameParts[1], nameParts[2]),       // "First Middle Last"
_ => throw new ArgumentException("Author name must be in 'First Last' or 'First Middle Last' format.", nameof(authorName))
};
}



}