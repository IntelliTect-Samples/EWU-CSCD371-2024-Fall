namespace Logger;

public abstract record class Entity : IEntity
{
    // Explicit implementation
    Guid IEntity.Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

    // Implicit implementation
    public abstract string Name { get; }
}
