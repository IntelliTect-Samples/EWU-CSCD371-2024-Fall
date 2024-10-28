namespace Logger;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; init; }
    public abstract string Name { get; }
}
