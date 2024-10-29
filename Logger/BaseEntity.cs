namespace Logger;
public abstract record class BaseEntity : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    // Adding abstract to the class to ensure deriving classes implement the property.
    public abstract string Name { get; set; }

    // Utilizing implicit implementation to force dervied classes to implement the method.
}
