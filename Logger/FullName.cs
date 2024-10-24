namespace Logger;

public readonly record struct FullName
{
    // FullName is defined as a record struct (value type) because names are typically small lightweight data. 
    // Value types are more appropriate for immutable,short-lived data that represents a single value, like a name.

    // FullName is immutable because it's defined as a readonly record struct.
    // This ensures that once a FullName instance is created, its properties cannot be changed.
    // If we need to change a name, we ensured that we can just create a new FullName record and replace it in the classes that use it.

    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }

    public FullName(string firstName, string lastName, string middleName = "")
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
    }

    public string OutputDetails() => MiddleName switch
    {
        "" => $"{FirstName} {LastName}",
        _ => $"{FirstName} {MiddleName} {LastName}"
    };
}