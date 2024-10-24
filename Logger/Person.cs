namespace Logger;

public record Person(FullName PersonsName, String Ssn, int Age, string DateOfBirth) : EntityBase
{
    private string FirstName { get; } = PersonsName.FirstName ?? throw new ArgumentNullException(nameof(FullName.FirstName));
    private string LastName { get; } = PersonsName.LastName ?? throw new ArgumentNullException(nameof(FullName.LastName));
    private string? MiddleName { get; } = PersonsName.MiddleName;
    
public override string Name => string.IsNullOrWhiteSpace(MiddleName) 
    ? $"{FirstName} {LastName}"
    : $"{FirstName} {MiddleName} {LastName}";
}
