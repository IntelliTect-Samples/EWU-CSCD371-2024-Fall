namespace Assignment;

public class Address : IAddress
{
    public Address(string streetAddress, string city, string state, string zip)
    {
        StreetAddress = string.IsNullOrWhiteSpace(streetAddress) ? throw new ArgumentException($"{nameof(streetAddress)} cannot be null or empty.", nameof(streetAddress)) : streetAddress;
        City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException($"{nameof(city)} cannot be null or empty.", nameof(city)) : city;
        State = string.IsNullOrWhiteSpace(state) ? throw new ArgumentException($"{nameof(state)} cannot be null or empty.", nameof(state)) : state;
        Zip = string.IsNullOrWhiteSpace(zip) ? throw new ArgumentException($"{nameof(zip)} cannot be null or empty.", nameof(zip)) : zip;
    }

    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}