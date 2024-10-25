namespace Logger;

public abstract record class Person : BaseEntity
{
    public FullName FullName { get; init; }

    public Person(FullName fullName)
    {
        FullName = fullName;
    }

    public override string Name => FullName.ToString();
}
