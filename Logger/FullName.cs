namespace Logger;

public readonly record struct FullName
{

    public string FirstName { get; }
    public string LastName { get; }
    public string MiddleName { get; }

    public FullName(string firstName, string lastName, string middleName = "")
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or whitespace.", nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
    }

    public override string ToString() => MiddleName switch
    {
        "" => $"{FirstName} {LastName}",
        _ => $"{FirstName} {MiddleName} {LastName}"
    };
}