namespace Logger;

public abstract record class Person : BaseEntity
{
    public FullName FullName { get; init; }
    public string Ssn { get; init; }
    public string Email { get; set; }
    public string DateOfBirth { get; init; }
    public Person(string firstName, string middleName, string lastName, string ssn, string email, string dateOfBirth)
    {
        FullName = new FullName(){FirstName = firstName, MiddleName = middleName, LastName = lastName};
        Ssn = ssn;
        Email = email ?? "N/A";
        DateOfBirth = dateOfBirth;
    }
    public override string ParseName() 
    {
        return FullName.ToString();
    }

}