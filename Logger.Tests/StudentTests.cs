
using System.Diagnostics;
using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void Constructor_AllValidInputs_CreatesStudent()
    {
        //Arrange

        //Act
        Student s = new ("MySchoolName", "FirstName", "LastName", "MiddleName") { GradeLevel = "12th" };
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
        Student s = new ("MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };
        //Assert
        Assert.NotNull(s);
        Assert.Equal("FirstName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
        Assert.Equal("12th",s.GradeLevel);
    }



    [Fact]
    public void Equals_MatchingStudent_ReturnsTrue()
    {
        //Arrange
        Student s = new("MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };
        Student s2 = new ("MySchoolName", "FirstName", "LastName") { GradeLevel = "12th" };
        //Act

        //Assert
        Assert.True(s.Equals(s2));
        Assert.True(s == s2);
    }
}
