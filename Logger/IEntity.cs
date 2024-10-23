namespace Logger;
public interface IEntity
{

    // Place members here.
    public string Name { get; }
    public Guid Id { get; init; }
}