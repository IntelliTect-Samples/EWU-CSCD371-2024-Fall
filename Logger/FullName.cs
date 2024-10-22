namespace Logger;

// We chose to define a value type here because we want to ensure that the FullName is immutable.
// The type is immutable because it is a readonly struct, furthermore, your name isn't going to change (for the most part).
public readonly record struct FullName(string firstName, string? middleName, string lastName)
{
    public FullName(string firstName, string lastName) : this(firstName, null, lastName) { }

    public override string ToString() => middleName is null ? $"{firstName} {lastName}" : $"{firstName} {middleName} {lastName}";
}
