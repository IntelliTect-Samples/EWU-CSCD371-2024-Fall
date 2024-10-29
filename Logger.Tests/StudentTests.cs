using Xunit;

namespace Logger.Tests;
    public class StudentTests
    {
    [Fact]
    public void Student_ValidData_CreatesRecord()
    {
        // Arrange
        var name = "John Middle Doe";
        var schoolName = "Rogers High School";
        var studentID = 319171;

        //Act
        Student david = new(name, schoolName, studentID);

        // Act & Assess
        Assert.NotNull(david);
        Assert.Equal(david.ID, studentID);
        Assert.Equal("John", david.FullName.FirstName);
        Assert.Equal("Middle", david.FullName.MiddleName);
        Assert.Equal("Doe", david.FullName.LastName);
        Assert.Equal(david.SchoolName, schoolName);
        Assert.Equal(david.Name, name);
    }

    [Fact]
    public void Student_ValidDatNoMiddle_CreatesRecordNoMiddleName()
    {
        // Arrange
        var name = "John Doe";
        var schoolName = "Rogers High School";
        var studentID = 319171;

        //Act
        Student david = new(name, schoolName, studentID);

        // Act & Assess
        Assert.NotNull(david);
        Assert.Equal(david.ID, studentID);
        Assert.Equal("John", david.FullName.FirstName);
        Assert.Null(david.FullName.MiddleName);
        Assert.Equal("Doe", david.FullName.LastName);
        Assert.Equal(david.SchoolName, schoolName);
    }
}
