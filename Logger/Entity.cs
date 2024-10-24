namespace Logger
{
    public abstract record class Entity : IEntity
    {
        // Applying the init setter here on the class.
        public Guid Id { get; init; }

        // Adding abstract to the class to ensure deriving classes implement the property.
        public abstract string Name { get; set; }

    }
}