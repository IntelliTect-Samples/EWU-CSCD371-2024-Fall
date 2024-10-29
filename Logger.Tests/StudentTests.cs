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
        Assert.Equal(david.StudentID, studentID);
        Assert.Equal("John", david.StudentName.FirstName);
        Assert.Equal("Middle", david.StudentName.MiddleName);
        Assert.Equal("Doe", david.StudentName.LastName);
        Assert.Equal(david.SchoolName, schoolName);

    }
}
