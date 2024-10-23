namespace Logger;

public abstract record class Person : Entity
{
    public Person(string first, string last, string id, string? middle = null)
    {
        PersonFullName = new FullName() { First = first, Last = last, Middle = middle } ;
        Id = id ?? throw new ArgumentNullException(nameof(id), $"{nameof(id)} was null.");
    }
    public FullName PersonFullName { get; set; } 
    public string Id { get; init; }
    protected override string ParseName()
    {
        return PersonFullName.ToString();
    }
}