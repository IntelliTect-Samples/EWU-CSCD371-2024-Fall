namespace Logger;


public record Student : Person
{
    
    public Student(string firstName, string? middleName, string lastName, string email, 
        string phoneNumber, string schoolName, string year, string major) 
        : base(Guid.NewGuid(), new FullName(firstName,middleName,lastName), email, phoneNumber) 
    { 
        
    }
    
}
