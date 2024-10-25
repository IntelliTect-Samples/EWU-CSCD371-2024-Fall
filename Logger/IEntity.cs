namespace Logger;
public interface IEntity
{
    string Name { get; }
    Guid Id{ get; init; }
}
