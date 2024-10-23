namespace Logger;

public abstract record class Person(FullName NameDetails) : EntityBase
{
    public FullName NameDetails { get; set; } = NameDetails;

    public override string Name
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(NameDetails.MiddleName))
            {
                return $"{NameDetails.FirstName} {NameDetails.MiddleName} {NameDetails.LastName}";
            }
            return $"{NameDetails.FirstName} {NameDetails.LastName}";
        }
    }
}