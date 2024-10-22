namespace Logger;
public interface IEntity
{
    string Name { get; }
    Guid ID { get; init; }
}
