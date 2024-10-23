namespace Logger;

// DO use the readonly modifier on a struct definition, making value types immutable.
// Logically, this represents a single value.
// We chose to define a value type here because we want to ensure that the FullName is immutable.
// The type is immutable because it is a readonly struct, furthermore, your name isn't going to change (for the most part).
public readonly record struct FullName(string FirstName, string? MiddleName, string LastName)
{
    public FullName(string FirstName, string LastName) : this(FirstName, null, LastName) { }

    public override string ToString() => MiddleName is null ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
}
