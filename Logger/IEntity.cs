namespace Logger;
public interface IEntity
{
    //TODO: Add comments explaining why we chose implicit implementation
    Guid Id { get; }
    string Name { get; }
}
