using System.Reflection;

namespace Logger;
public record class Book : BaseEntity
{

    //These properties are implemented implicitly, as they belong to Book and do not require special handling.
public string Title { get; init;}
public FullName Author { get; set;}
public int YearPublished { get; init;}
public int ISBN { get; init; }

    // Implementing the Name property from BaseEntity explicitly to provide a calculated property.
    // This implementation is explicit to enforce that Name is derived from Title, Author, and ISBN 
    // and is not stored in a separate field, maintaining the requirement for a calculated value.
    public override string Name
{
    get => $"{Title} by {Author.ToString()} (ISBN: {ISBN})";

    set => throw new InvalidOperationException("The Name property is calculated and cannot be set directly.");
}

public Book(string title, string authorName, int yearPublished, int isbn)
{
Title = title ?? throw new ArgumentNullException(nameof(title), $"{nameof(title)} was null.");

Author = ParseAuthor(authorName);
YearPublished = yearPublished;
ISBN = isbn;
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