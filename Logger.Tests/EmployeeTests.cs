using Xunit;

namespace Logger.Tests;

public class EmployeeTests
{
    [Theory]
    [InlineData("EmployeeID", "Position", "First", "Last", "Middle")]
    public void Constructor_AllParamaters_MakesEmployee(string employeeId, string position, string first, string last, string middle)
    {
        //Arrange
        Employee employee = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.NotNull(employee);
        Assert.Equal(employee.EmployeeID, employeeId);
        Assert.Equal(employee.Position, position);
        Assert.Equal(employee.EmployeeFullName.First, first);
        Assert.Equal(employee.EmployeeFullName.Middle, middle);
        Assert.Equal(employee.EmployeeFullName.Last, last);
    }

    [Theory]
    [InlineData("EmployeeID", "Position", "First", "Last")]
    public void Constructor_AllParamatersExceptMiddle_MakesEmployee(string employeeId, string position, string first, string last)
    {
        //Arrange
        Employee employee = new("EmployeeID", "Position", "First", "Last", "Middle");

        //Act

        //Assert
        Assert.NotNull(employee);
        Assert.Equal(employee.EmployeeID, employeeId);
        Assert.Equal(employee.Position, position);
        Assert.Equal(employee.EmployeeFullName.First, first);
        Assert.Equal(employee.EmployeeFullName.Last, last);
    }
}
