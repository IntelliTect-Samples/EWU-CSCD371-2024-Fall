namespace Logger;

public abstract record class Entity : IEntity
{
    // Explicit implementation
    public Guid Id { get; init; } = Guid.NewGuid();

    // Implicit implementation
    public abstract string Name { get; }
}
