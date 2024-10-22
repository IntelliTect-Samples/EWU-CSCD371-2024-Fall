
using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void Constructor_AllValidInputs_CreatesStudent()
    {
        //Arrange

        //Act
        Student s = new Student("MySchoolName", "FirstName", "LastName", "MiddleName");
        //Assert
        Assert.NotNull(s);
        Assert.Equal("FirstName MiddleName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
    }
    [Fact]
    public void Constructor_NoMiddleName_CreatesStudent()
    {
        //Arrange

        //Act
        Student s = new Student("MySchoolName", "FirstName", "LastName");
        //Assert
        Assert.NotNull(s);
        Assert.Equal("FirstName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
    }

    [Fact]
    public void GradeLevel_ValidString_StoresGradeLevel()
    {
        //Arrange
        Student s = new Student("MySchoolName", "FirstName", "LastName");
        //Act
        s.GradeLevel = "12th Grade";
        //Assert
        Assert.Equal("12th Grade",s.GradeLevel);
    }
    [Fact]
    public void Equals_MatchingStudent_ReturnsTrue()
    {
        //Arrange
        Student s = new Student("MySchoolName", "FirstName", "LastName");
        Student s2 = new Student("MySchoolName", "FirstName", "LastName");
        s.GradeLevel = "12th";
        s2.GradeLevel = "12th";
        //Act

        //Assert
        Assert.True(s.Equals(s2));
        Assert.True(s == s2);
    }
}
