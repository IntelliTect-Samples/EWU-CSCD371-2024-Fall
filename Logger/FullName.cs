namespace Logger;

public record FullName
{
    public FullName(string firstName, string? middleName, string lastName)
    {
        // FirstName cannot be null or whitespace. Every person has a first name.
        FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentNullException(nameof(firstName), $"'{nameof(firstName)}' cannot be null or whitespace.")
                : firstName;

        // MiddleName can be null. Not every person has a middle name.

        MiddleName = string.IsNullOrWhiteSpace(middleName)
                ? null
                : middleName;

        // LastName cannot be null or whitespace. Every person has a last name.
        LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentNullException(nameof(lastName), $"'{nameof(lastName)}' cannot be null or whitespace.")
                : lastName;
    }
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }

    public override string ToString()
    {
        return (MiddleName != null) ? $"{FirstName} {MiddleName} {LastName}" : $"{FirstName} {LastName}";
    }


}