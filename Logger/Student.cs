namespace Logger;


public record Student : Person
{
    
    public Student(FullName name, string email, 
        string phoneNumber, string schoolName, string year, string major) 
        : base(Guid.NewGuid(), name, email, phoneNumber) 
    { 
        
    }
    
}
