namespace Logger;

public record class Student(FullName NameDetails) : Person(NameDetails)
{
    private double? _gpa;

    public double? Gpa
    {
        get => _gpa;
        set
        {
            if (value is not null && (value < 0.0 || value > 4.0))
            {
                throw new ArgumentException("GPA must be between 0.0 and 4.0 if provided.", nameof(value));
            }
            _gpa = value;
        }
    }
    public Student(FullName nameDetails, double? gpa = null) : this(nameDetails)
    {
        Gpa = gpa;
    }
}