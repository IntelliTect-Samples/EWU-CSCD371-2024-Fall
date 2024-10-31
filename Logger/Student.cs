namespace Logger;

public record Student : Person
{
    private string? _studentId;
    private int _schoolYear;
    private bool _isUndergrad;
    private double _gpa;
    private string? _major;

    public Student(FullName fullName, string studentId, int schoolYear, bool isUndergrad, double gpa, string major) : base(fullName)
    {
        StudentId = studentId;
        SchoolYear = schoolYear;
        IsUndergrad = isUndergrad;
        Gpa = gpa;
        Major = major;
    }

    public string StudentId
    {
        get => _studentId!;
        set
        {
            ArgumentNullException.ThrowIfNull(value, "ID cannot be null");
            _studentId = value;
        }
    }

    public int SchoolYear
    {
        get => _schoolYear;

        set
        {
            // Can be above 4 in case of super seniors
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, "SchoolYear must be 1 or higher");
            _schoolYear = value;
        }
    }

    public bool IsUndergrad 
    { 
        get => _isUndergrad; 
        set 
        { 
            _isUndergrad = value; 
        } 
    }

    public double Gpa
    {
        get => _gpa;

        set
        {
            if(value < 0 || value > 4)
            {
                throw new ArgumentException("GPA must be between 0 and 4");
            }
            _gpa = value;
        }
    }

    public string Major
    {
        get => _major!;
        set
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value, "Major cannot be null");
            _major = value;
        }
    }
}
