
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
    public void AddClass_VaidString_AddsClass() {
        //Arrange
        string? nullString = null;
        //Act
        Student s = new Student("MySchoolName", "FirstName", "LastName");
        s.AddClasses("class1");
        s.AddClasses("class2");
        s.AddClasses("");
        s.AddClasses(nullString);
        //Assert
        Assert.NotNull(s);
        Assert.Equal("FirstName LastName", s.Name);
        Assert.Equal("MySchoolName", s.SchoolName);
        Assert.Contains("class1", s.CurrentClasses);
        Assert.Contains("class2", s.CurrentClasses);
        Assert.Equal(2, s.CurrentClasses.Count);
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
}
