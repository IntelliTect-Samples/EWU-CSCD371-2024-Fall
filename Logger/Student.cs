namespace Logger;

public record class Student(FullName NameDetails) : Person(NameDetails)
{
    // GPA can be null, so we use double? (nullable double)
    private double? _gpa;

    // Public property for GPA with validation and mutability
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

    // Constructor to optionally allow GPA initialization
    public Student(FullName nameDetails, double? gpa = null) : this(nameDetails)
    {
        Gpa = gpa; // Handle optional GPA during initialization
    }
}