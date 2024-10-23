namespace Logger
{
    public record class Employee(FullName NameDetails) : Person(NameDetails)
    {
    }
}