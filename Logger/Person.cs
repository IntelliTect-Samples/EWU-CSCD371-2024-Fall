namespace Logger;

public record Person(Guid Id, FullName FullName, string Email, string PhoneNumber) : EntityBase
{

    public new Guid Id { get; } = Id != Guid.Empty ? Id : throw new ArgumentNullException(nameof(Id));
    public string FirstName { get; } = FullName.FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = FullName.LastName ?? throw new ArgumentNullException(nameof(LastName));
    
    private string? MiddleName { get; } = FullName.MiddleName;
    
    // Implementing the Name property from IEntity interface
   public override string Name => MiddleName is null ? $"{FirstName} {LastName}" 
       : $"{FirstName} {MiddleName} {LastName}";
   
}