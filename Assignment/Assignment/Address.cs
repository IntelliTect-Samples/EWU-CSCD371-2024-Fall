namespace Assignment;

public class Address : IAddress
{
    public Address(string streetAddress, string city, string state, string zip)
    {
        StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(streetAddress), $"{nameof(streetAddress)} cannot be null.");
        City = city ?? throw new ArgumentNullException(nameof(city), $"{nameof(city)} cannot be null.");
        State = state ?? throw new ArgumentNullException(nameof(state), $"{nameof(state)} cannot be null.");
        Zip = zip ?? throw new ArgumentNullException(nameof(zip), $"{nameof(zip)} cannot be null.");
    }

    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}