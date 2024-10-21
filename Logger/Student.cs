
using System.Globalization;

namespace Logger;

public record class Student : Entity
{
    public FullName MyFullName { get; set; }
    public string SchoolName { get; set; }
    public string? GradeLevel { get; set; }

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


}
