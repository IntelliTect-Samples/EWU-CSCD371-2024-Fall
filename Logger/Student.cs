
using System.Globalization;

namespace Logger;

public record class Student : Entity
{
    private FullName MyFullName { get; set; }
    public string SchoolName { get; set; }
    public string? GradeLevel { get; set; }
    public List<string> Grades { get; set; } = new List<string>();
    public List<string> CurrentClasses { get; set; } = new List<string>();


    public Student(string school, string first, string last, string? middle = null)
    {

        MyFullName = new() { First = first, Last = last, Middle = middle };
        SchoolName = school ?? throw new ArgumentNullException(nameof(school),"School string was null");
    }
    protected override string ParseName()
    {
       if(MyFullName.Middle is null) return MyFullName.First + " " + MyFullName.Last;
       return MyFullName.First + " " + MyFullName.Middle + " " + MyFullName.Last;
    }

    public void AddClasses(string? studentClass)
    {
        if (!string.IsNullOrEmpty(studentClass)) CurrentClasses.Add(studentClass);
    }
    public void AddClasses(List<string> studentClasses)
    {
        if (studentClasses == null) return;
        foreach (string singleClass in studentClasses!) {

            if (!string.IsNullOrEmpty(singleClass))CurrentClasses.Add(singleClass);
            
        }

        }
}
