namespace Logger;

public record Book : IEntity
{
    public Book(Guid id, string name, string author, string genre, string publisher, int year, int pages, string language, string isbn)
    {
        Name = name;  // This should be title ?
    }



    public Guid Id { get; init; }
    public string Name { get; }

}