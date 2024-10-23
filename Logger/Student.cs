namespace Logger;

public record class Student(string id, string school, string first, string last, string? middle = null) : Person(first, last, id, middle)
{
    public string SchoolName = school ?? throw new ArgumentNullException(nameof(school), $"{nameof(school)} was null");
    public string? GradeLevel { get; set; }
}