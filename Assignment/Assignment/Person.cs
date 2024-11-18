namespace Assignment;

public class Person : IPerson
{
    public Person(string firstName, string lastName, IAddress address, string emailAddress)
    {
        FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentException($"{nameof(firstName)} cannot be null or whitespace.") : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentException($"{nameof(lastName)} cannot be null or whitespace.") : lastName;
        Address = address;
        EmailAddress = string.IsNullOrWhiteSpace(emailAddress) ? throw new ArgumentException($"{nameof(emailAddress)} cannot be null or whitespace.") : emailAddress;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAddress Address { get; set; }
    public string EmailAddress { get; set; }
}