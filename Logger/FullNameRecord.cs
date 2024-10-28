namespace Logger;

//FullNameRecord is a vaule type of record struct for efficiency and immutability.
//record struct is immutable by design and cannot be change.
public readonly record struct FullNameRecord(string firstName, string lastName, string? middleName = null)
{
    public string firstName { get; } = firstName ?? throw new ArgumentNullException(nameof(firstName));
    public string lastName { get; } = lastName ?? throw new ArgumentNullException(nameof(lastName));
    public string? middleName { get; } = middleName;
}
