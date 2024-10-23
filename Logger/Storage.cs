namespace Logger;
/// <summary>
/// Contains:<br/>
/// <seealso cref="HashSet{IEntity}"/><br/>
/// <seealso cref="Add(IEntity)"/><br/>
/// <seealso cref="Remove(IEntity)"/><br/>
/// <seealso cref="Contains(IEntity)"/><br/>
/// <seealso cref="Get(Guid)"/><br/>
/// <br/>
/// Contains an entity hashset that we can perform on.
/// </summary>
public class Storage
{
    private HashSet<IEntity> Entities { get; } = new();
    
    public void Add(IEntity item)
    {
        Entities.Add(item);
    }

    public void Remove(IEntity item)
    {
        Entities.Remove(item);
    }

    public bool Contains(IEntity item)
    {
        return Entities.Contains(item);
    }
    
    public IEntity? Get(Guid expectedGuid)
    {
        return Entities.FirstOrDefault(entity => 
        {
            dynamic dynamicEntity = entity;
            return ((IEntity)dynamicEntity).Id == expectedGuid;
        });
    }
}
