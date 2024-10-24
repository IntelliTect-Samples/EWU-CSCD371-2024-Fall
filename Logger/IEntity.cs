namespace Logger;
public interface IEntity
{
    public Guid Id { get; }
    
    public string Name { get; set; }

}
