using System;

namespace Logger;
    public abstract record class Person : BaseEntity
{


    // Common properties. ID and Name may change.
    public FullName FullName { get; set; }
    public int ID { get; set; }

    // Constructor to initialize common properties
    protected Person(string name, int id)
    {
        FullName = ParseName(name);
        ID = id;
    }

    // Method to parse the full name from a single string input
    protected static FullName ParseName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentNullException(nameof(fullName), "Name cannot be null or whitespace.");
        }

        var nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return nameParts.Length switch
        {
            2 => new FullName(nameParts[0], null, nameParts[1]),               // "First Last"
            3 => new FullName(nameParts[0], nameParts[1], nameParts[2]),       // "First Middle Last"
            _ => throw new ArgumentException("Name must be in 'First Last' or 'First Middle Last' format.", nameof(fullName))
        };
    }

    // Implement Name property from BaseEntity as a calculated property
    public override string Name
    {
        get => $"{FullName.ToString()}";
        set => throw new InvalidOperationException("The Name property is calculated and cannot be set directly.");
    }
}
