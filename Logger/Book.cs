namespace Logger;

public record class Book
{
    public required string ISBN { get; init; }
    public required string Author { get; init; }
    public required int PublicationYear { get; init; }
    public required string Title { get; init; }
}