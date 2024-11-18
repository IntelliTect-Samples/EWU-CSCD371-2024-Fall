namespace Assignment;

public class Person : IPerson
{
    public Person(string firstName, string lastName, IAddress address, string emailAddress)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName), $"{nameof(firstName)} cannot be null.");
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName), $"{nameof(lastName)} cannot be null.");
        Address = address ?? throw new ArgumentNullException(nameof(address), $"{nameof(address)} cannot be null.");
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress), $"{nameof(emailAddress)} cannot be null.");
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAddress Address { get; set; }
    public string EmailAddress { get; set; }
}