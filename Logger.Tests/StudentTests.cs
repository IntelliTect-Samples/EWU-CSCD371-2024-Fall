using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void Constructor_AllValidInputs_CreatesStudent()
    {
        //Arrange

        //Act
        Student s = new("StudentID-12345", "MySchoolName", "FirstName", "LastName", "MiddleName") { GradeLevel = "12th" };

        //Assert
        Assert.NotNull(s);
        Assert.Equal("StudentID-12345", s.Id);
        Assert.Equal("FirstName MiddleName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
    }

    [Fact]
    public void Constructor_NoMiddleName_CreatesStudent()
    {
        //Arrange

        //Act
        Student s = new("StudentID-12345", "MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };

        //Assert
        Assert.NotNull(s);
        Assert.Equal("StudentID-12345", s.Id);
        Assert.Equal("FirstName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
        Assert.Equal("12th", s.GradeLevel);
    }

    [Fact]
    public void Equals_MatchingStudent_ReturnsTrue()
    {
        //Arrange
        Student s = new("StudentID-12345", "MySchoolName", "FirstName", "LastName") { GradeLevel = "10th" };
        Student s2 = new("StudentID-12345", "MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };
        Student s3 = new("StudentID-12345", "MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };
        Student s4 = s;

        //Act
        s.GradeLevel = "12th";
        s.PersonFullName = new FullName() { First = "FirstName", Last = "LastName" };

        //Assert

        Assert.False(s.Equals((Person)s2));
        Assert.False(((Person)s).Equals(s3));
        Assert.False(s2.Equals(s3));
        Assert.False(s == s2);
        Assert.False(s == s3);
        Assert.False(s2 == s);
        Assert.NotEqual(s, s2);
        Assert.Same(s, s4);
    }
}