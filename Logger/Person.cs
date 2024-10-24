namespace Logger;

public abstract record class Person(FullName NameDetails) : EntityBase
{
    public FullName NameRecord { get; set; } = NameDetails;

    public override string Name
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(NameRecord.MiddleName))
            {
                return $"{NameRecord.FirstName} {NameRecord.MiddleName} {NameRecord.LastName}";
            }
            return $"{NameRecord.FirstName} {NameRecord.LastName}";
        }
    }
}