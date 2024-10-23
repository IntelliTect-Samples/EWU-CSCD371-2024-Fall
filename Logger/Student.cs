namespace Logger;

public record class Student : Person
{
    public string SchoolName { get; set; }
    public string? GradeLevel { get; set; }
    public Student(string id, string school, string first, string last, string? middle = null) : base(first, last, id, middle)
    {
        SchoolName = school;
    }


}