using Xunit;

namespace Logger.Tests;
    public class StudentTests
    {
    [Fact]
    public void BookRecord_ValidData_CreatesRecord()
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
        Assert.Equal("John", david.Name.FirstName);
        Assert.Equal("Middle", david.Name.MiddleName);
        Assert.Equal("Doe", david.Name.LastName);
        Assert.Equal(david.SchoolName, schoolName);

    }
}
