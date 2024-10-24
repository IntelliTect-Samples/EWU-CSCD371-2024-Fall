namespace Logger;

public record FullName
{
    public FullName(string firstName, string? middleName, string lastName)
    {
        // FirstName cannot be null or whitespace. Every person has a first name.
        FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentException($"'{nameof(firstName)}' cannot be null or whitespace.", nameof(firstName))
                : firstName;

        // MiddleName can be null. Not every person has a middle name.

        MiddleName = string.IsNullOrWhiteSpace(middleName)
                ? null
                : middleName;

        // LastName cannot be null or whitespace. Every person has a last name.
        LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(lastName))
                : lastName;
    }

    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }
}