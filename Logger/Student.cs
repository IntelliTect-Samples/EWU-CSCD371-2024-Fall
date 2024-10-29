namespace Logger;

public record Student : Person
{
    public string StudentId { get; init; }

    public Student(FullName fullName, string studentId) : base(fullName)
    {
        StudentId = studentId;
    }

    // Explicitly implementing GetId to return the StudentId
    // This provides a way to get the unique id for a Student
    protected override string GetId() => StudentId;
}
