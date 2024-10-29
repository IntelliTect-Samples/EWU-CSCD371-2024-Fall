namespace Logger;

public abstract record class BaseEntity : IEntity
{
    /*
     *  This is an explicit impementation.
     *  Guid ID is declared here, so that if a child wants to have a different id, ex. student id, it can be done.
     */
    public Guid Id { get; init; } = Guid.NewGuid();
    /*
     *  This is an implicit implementation.
     *  If the child has a certain implementation for formatting on the name, it can be done in the child class.
     *  ex. Book class
     */
    public abstract string Name { get; }
}
