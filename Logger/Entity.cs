
namespace Logger;

public abstract record class Entity : IEntity
{
    private Guid _guid;
    public Guid Id { get => _guid!; init { _guid = Guid.NewGuid(); } }

    public string Name => ParseName();
    protected abstract string ParseName();
    
}
