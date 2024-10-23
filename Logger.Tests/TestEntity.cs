namespace Logger.Tests;

public class TestEntity : IEntity
{
    private Guid _id;
    private string? _name;

    public required string Name 
    {
        get => _name!;
        set {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            _name = value;
        }
    }

    public required Guid Id { get => _id!; init => _id = value; }
}