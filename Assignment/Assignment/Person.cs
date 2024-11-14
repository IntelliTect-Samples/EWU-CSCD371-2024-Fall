
namespace Assignment
{
    public class Person(string firstName, string lastName, IAddress address, string emailAddress) : IPerson
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public IAddress Address { get; set; } = address;
        public string EmailAddress { get; set; } = emailAddress;
    }
}
