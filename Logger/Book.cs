using System.Globalization;

namespace Logger;

#pragma warning disable CA1311
#pragma warining disable CA1304

public record Book (string Title, FullName Author, string? Genre, string Publisher, 
    int Year, string Isbn): EntityBase
{
    
    public FullName Author { get; } = Author ?? throw new ArgumentNullException(nameof(Author));
    public string Title { get; } = !string.IsNullOrWhiteSpace(Title) 
        ? Title 
        : throw new ArgumentException("Title cannot be null or empty.", nameof(Title));

    public string Isbn { get; } = !string.IsNullOrWhiteSpace(Isbn)
        ? Isbn
        : throw new ArgumentException("ISBN cannot be null or empty.", nameof(Isbn).ToLowerInvariant());
    
    public string Publisher { get; } = Publisher ?? throw new ArgumentNullException(nameof(Publisher).
        ToLowerInvariant());

    public override string Name => string.IsNullOrWhiteSpace(Author.MiddleName) 
        ? $"{Author.FirstName} {Author.LastName}"
        : $"{Author.FirstName} {Author.MiddleName} {Author.LastName}";
    
}