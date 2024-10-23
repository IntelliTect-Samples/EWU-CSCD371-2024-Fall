using Xunit;

namespace Logger.Tests;

public class EmployeeTests
{
    [Theory]
    [InlineData("EmployeeID", "Position", "First", "Last", "Middle")]
    public void Constructor_AllParamaters_MakesEmployee(string employeeId, string position, string first, string last, string middle)
    {
        //Arrange
        Employee expectedEmployee = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.NotNull(expectedEmployee);
        Assert.Equal(expectedEmployee.Id, employeeId);
        Assert.Equal(expectedEmployee.Position, position);
        Assert.Equal(expectedEmployee.PersonFullName.First, first);
        Assert.Equal(expectedEmployee.PersonFullName.Middle, middle);
        Assert.Equal(expectedEmployee.PersonFullName.Last, last);
    }

    [Theory]
    [InlineData("EmployeeID", "Position", "First", "Last")]
    public void Constructor_AllParamatersExceptMiddle_MakesEmployee(string employeeId, string position, string first, string last)
    {
        //Arrange
        Employee expectedEmployee = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.NotNull(expectedEmployee);
        Assert.Equal(expectedEmployee.Id, employeeId);
        Assert.Equal(expectedEmployee.Position, position);
        Assert.Equal(expectedEmployee.PersonFullName.First, first);
        Assert.Equal(expectedEmployee.PersonFullName.Last, last);
    }

    [Theory]
    [InlineData(null, "Position", "First", "Last", "Middle")]
    [InlineData("EmployeeID", null, "First", "Last", "Middle")]
    [InlineData("EmployeeID", "Position", null, "Last", "Middle")]
    [InlineData("EmployeeID", "Position", "First", null, "Middle")]
    public void Constructor_BadParamaters_ThrowsException(string? employeeId, string? position, string? first, string? last, string? middle)
    {
        //Arrange

        //Act

        //Assert
        Assert.ThrowsAny<ArgumentException>(() => new Employee(employeeId!, position!, first!, last!, middle!));
    }

    [Theory]
    [InlineData("135092", "Boss", "Tyler", "Woody", "Middle")]
    public void ParseName_AllParamaters_DisplaysName(string employeeID, string position, string first, string last, string middle)
    {
        //Arrange
        Employee employee = new(employeeID, position, first, last, middle);

        //Act
        string expectedName = "Tyler Middle Woody";
        string actualName = employee.Name;

        //Assert
        Assert.Equal(expectedName, actualName);
    }

    [Theory]
    [InlineData("135092", "Boss", "Tyler", "Woody")]
    public void ParseName_AllParamatersExceptMiddle_DisplaysName(string employeeID, string position, string first, string last)
    {
        //Arrange
        Employee employee = new(employeeID, position, first, last);

        //Act
        string expectedName = "Tyler Woody";
        string actualName = employee.Name;

        //Assert
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public void Constructor_MatchingEmployee_ReturnsTrue()
    {
        //Arrange
        Employee employee1 = new("EmployeeID", "Position", "First", "Last", "Middle");
        Employee employee2 = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.True(employee1.Equals(employee2));
    }
}