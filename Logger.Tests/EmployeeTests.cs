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
        Assert.Equal(expectedEmployee.EmployeeID, employeeId);
        Assert.Equal(expectedEmployee.Position, position);
        Assert.Equal(expectedEmployee.EmployeeFullName.First, first);
        Assert.Equal(expectedEmployee.EmployeeFullName.Middle, middle);
        Assert.Equal(expectedEmployee.EmployeeFullName.Last, last);
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
        Assert.Equal(expectedEmployee.EmployeeID, employeeId);
        Assert.Equal(expectedEmployee.Position, position);
        Assert.Equal(expectedEmployee.EmployeeFullName.First, first);
        Assert.Equal(expectedEmployee.EmployeeFullName.Last, last);
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
}
