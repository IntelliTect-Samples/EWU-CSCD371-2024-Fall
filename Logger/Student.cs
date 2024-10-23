using System.Collections.Generic;
using System.Reflection;

namespace Logger;

public record class Student(string school, string id, string first, string last, string middle = "") : Person(first, last, "123455", middle)
{

    public string SchoolName = school ?? throw new ArgumentNullException(nameof(school), "School string was null");
    public string? GradeLevel { get; set; }


}