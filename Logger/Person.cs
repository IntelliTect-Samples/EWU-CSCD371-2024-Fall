namespace Logger;

public abstract record class Person : Entity
{
    public FullName FullName { get; init; }

    // Implicitly implementing Name from Entity as a formatted string based on FullName.
    // This implementation allows derived classes to inherit it
    public override string Name => FullName.ToString();

    // Override of ToString to show a string combining Name and id
    // This provides a consistent string for all derived types
    public override string ToString() => $"{Name} (ID: {GetId()})";

    protected abstract string GetId(); // Abstract method to get ID that each derived class must implement

    public Person(FullName fullName)
    {
        FullName = fullName;
    }
}
