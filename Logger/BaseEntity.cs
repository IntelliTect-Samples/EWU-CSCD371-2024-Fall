namespace Logger;
public abstract record class BaseEntity : IEntity
{
    // Applying the init setter here on the class, set during the initialization and immutable thereafter.
    public Guid Id { get; init; }

    // Adding abstract to the class to ensure deriving classes implement the property.
    public abstract string Name { get; set; }

    // Utilizing implicit implementation to force dervied classes to implement the method.
}
