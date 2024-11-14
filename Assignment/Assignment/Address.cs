namespace Assignment;

public class Address(string streetAddress, string city, string state, string zip) : IAddress
{
    public string StreetAddress { get; set; } = streetAddress;
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public string Zip { get; set; } = zip;
}
