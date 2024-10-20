

namespace Logger.Tests;

public class TestEntity : IEntity
{
    private Guid _id;

    public required string Name { get; set; }
    public Guid Id { get => _id!; init => _id = value; }
}
