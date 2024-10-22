namespace Logger;

#pragma warning disable CS8907;
public record Person(Guid Id, FullName FullName, string Email, string PhoneNumber) : EntityBase
{ 
    
    public override string Name
    {
        get => FullName.ToString();
    }
    
}