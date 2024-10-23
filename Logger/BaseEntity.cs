namespace Logger;

public abstract record class BaseEntity : IEntity
{
    public abstract string Name { get; }

    public Guid Id{ get; init; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid(); // unique for each entity
    }
}    
