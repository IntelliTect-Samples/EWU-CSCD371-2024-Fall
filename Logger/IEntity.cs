namespace Logger;

/*
 Instructions:
    Define an IEntity interface: ✔
    Add an Id property of type Guid that is an init-only setter. ✔
    Add a Name property that is string. ✔
*/
public interface IEntity
{
    public Guid Id { get; }
    public string Name { get; }
}
