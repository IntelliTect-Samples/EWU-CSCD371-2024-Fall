namespace Logger;

public record Person(Guid Id, FullName FullName, string Email, string PhoneNumber) : IEntity
{
    public Person(string FirstName, string LastName, string Email, string? MiddleName, string phoneNumber)
        : this(Guid.NewGuid(), new FullName(FirstName, MiddleName, LastName), Email, phoneNumber){ }
    public string FirstName { get; } = FullName.FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = FullName.LastName ?? throw new ArgumentNullException(nameof(LastName));
    
    private string? MiddleName { get; } = FullName.MiddleName;
    
    // Implementing the Name property from IEntity interface
   public string Name => MiddleName is null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
}