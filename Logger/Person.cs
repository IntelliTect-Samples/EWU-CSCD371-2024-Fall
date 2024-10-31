namespace Logger;

public abstract record class Person : BaseEntity
{
    /*
        The Person Class is an abstract class that is used to create a Person object.
        The Person class inherits from the BaseEntity class.
        The Person class has the following properties:
        - FullName: A property of type FullName that represents the full name of the person.
        - Ssn: A string property that represents the social security number of the person.
        - Email: A string property that represents the email address of the person.
        - DateOfBirth: A string property that represents the date of birth of the person.
        The Person class has a constructor that initializes the properties of the class.
    */
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