namespace Logger;

public record class Student : Entity
{
    public FullName MyFullName { get; set; }
    public string ID { get; init; }
    public string SchoolName { get; set; }
    public string? GradeLevel { get; set; }

    public Student(string studentID, string school, string first, string last, string? middle = null)
    {
        MyFullName = new() { First = first, Last = last, Middle = middle };
        SchoolName = school ?? throw new ArgumentNullException(nameof(school),"School string was null");
        ID = studentID ?? throw new ArgumentNullException(nameof(studentID), $"{nameof(studentID)} was null.");
    }

    protected override string ParseName()
    {
        return MyFullName.ToString();
    }
}