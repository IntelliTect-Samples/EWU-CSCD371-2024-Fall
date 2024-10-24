namespace Logger;

public record Person(FullName PersonsName, String Ssn, int Age, string DateOfBirth) : EntityBase
{
    public FullName PersonsName { get; } = PersonsName ?? throw new ArgumentNullException(nameof(PersonsName));
    public string Ssn { get; } = !string.IsNullOrWhiteSpace(Ssn)
        ? Ssn
        : throw new ArgumentException("SSN cannot be null or empty.", nameof(Ssn).ToLower());
    public string DateOfBirth { get; } = !string.IsNullOrWhiteSpace(DateOfBirth)
        ? DateOfBirth
        : throw new ArgumentException("Date of Birth cannot be null or empty.", nameof(DateOfBirth));
    
    public override string Name => string.IsNullOrWhiteSpace(PersonsName.MiddleName)
        ? $"{PersonsName.FirstName} {PersonsName.LastName}"
        : $"{PersonsName.FirstName} {PersonsName.MiddleName} {PersonsName.LastName}";
}
