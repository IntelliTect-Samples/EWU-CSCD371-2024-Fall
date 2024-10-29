namespace Logger;

public abstract record class Person(FullName NameDetails) : BaseEntity
{
    public FullName LegalName { get; set; } = NameDetails;

    public override string Name => NameDetails.ToString();
}
