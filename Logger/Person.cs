namespace Logger;

public abstract record class Person : BaseEntity
{
    public FullName FullName { get; init; }
    public required string Ssn { get; init; }
    public string? Email { get; init; }
    public required string dateOFBirth { get; init; }
    public Person(FullName FullName, string ssn, string? email, string dateOfBirth)
    {
        this.FullName = FullName;
        this.Ssn = ssn;
        this.Email = email ?? "N/A";
        this.dateOFBirth = dateOfBirth;
    }
    public override string Name => FullName.ToString();

}