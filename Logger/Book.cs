using System;

namespace Logger;

public record class Book : EntityBase
{
    public override string Name => $"{Title} by {Author.OutputDetails()}";

    public string Title { get; init; }
    public FullName Author { get; init; }
    public string ISBN { get; init; }

    public Book(string title, FullName author, string isbn)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        }
        Title = title;

        Author = author;

        if (string.IsNullOrWhiteSpace(isbn))
        {
            throw new ArgumentException("ISBN cannot be null or empty.", nameof(isbn));
        }
        ISBN = isbn;
    }
}
