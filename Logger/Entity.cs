namespace Logger;

public abstract record class Entity : IEntity
{
    private Guid _guid;
    /// <summary>
    /// This is an Explicit declaration.
    /// Implementations may have their own Id value, and we want to seperate these.<br/>
    /// Ex: Student.Id Should not return a Guid, but instead a value that fits the school guidelines perhaps
    /// </summary>
    Guid IEntity.Id 
    { 
        get => _guid!; 
        init { _guid = Guid.NewGuid(); }
    }
    /// <summary>
    /// This method is explicit, as we feel calling an implementation directly is fine. Doing explicit would not help here.
    /// </summary>
    public string Name => ParseName();
    protected abstract string ParseName();
}