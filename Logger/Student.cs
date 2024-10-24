namespace Logger;


public record Student : Person
{
    
    public Student(string firstName, string? middleName, string lastName, string email, string schoolName, 
        string schoolYear, string major, string ssn, int age, string dateOfBirth) 
        : base(new FullName(firstName,middleName,lastName), ssn , age, dateOfBirth) 
    { 
        
    }
    
}
