namespace Logger;

public record struct FullNameRecord(string firstName, string lastName, string? middleName = null)
{
    public string firstName { get; } = firstName ?? throw new ArgumentNullException(nameof(firstName));
    public string lastName { get; } = lastName ?? throw new ArgumentNullException(nameof(lastName));
    public string? middleName { get; } = middleName;
}
