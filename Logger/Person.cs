namespace Logger;

public abstract record class Person(FullName NameDetails) : BaseEntity
{
    public FullName LegalName { get; set; } = NameDetails;

    // This is an explicit implementation, since everything inheriting is a person, we can do the explicit implementation here.
    public override string Name => NameDetails.ToString();
}
