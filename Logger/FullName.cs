namespace Logger;

//FullName is a value type of record struct because we want it to be immutable.
//record struct is immutable by design and cannot be change.
public readonly record struct FullName(string firstName, string lastName, string? middleName = null)
{
    public string firstName { get; } = firstName ?? throw new ArgumentNullException(nameof(firstName));
    public string? middleName { get; } = middleName;
    public string lastName { get; } = lastName ?? throw new ArgumentNullException(nameof(lastName));

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(middleName) ? $"{firstName} {lastName}":$"{firstName} {middleName} {lastName}";
    }
}
