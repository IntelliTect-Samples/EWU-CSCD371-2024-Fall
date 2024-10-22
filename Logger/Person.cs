namespace Logger;

public abstract record class Person(FullName NameDetails) : EntityBase
{
    public FullName NameDetails { get; set; } = NameDetails;

    public override string Name => NameDetails.ToString();
}