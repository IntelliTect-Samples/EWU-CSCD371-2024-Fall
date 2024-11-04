using Xunit;   

namespace Logger.Tests;
public class EmployeeTests
{

    [Fact]
    public void Employee_ValidData_CreatesRecord()
    {
        // Arrange
        var employeeName = "David Middle Moore";
        var employer = "Coding Dojo";
        var employeeRole = "Manager";
        var employeeID = 319171;

        //Act
        Employee david = new(employeeName, employer, employeeRole, employeeID);

        // Act & Assess
        Assert.NotNull(david);
        Assert.Equal(david.ID, employeeID);
        Assert.Equal("David", david.FullName.FirstName);
        Assert.Equal("Middle", david.FullName.MiddleName);
        Assert.Equal("Moore", david.FullName.LastName);
        Assert.Equal(david.EmployeeRole, employeeRole);
        Assert.Equal(david.Employer, employer);
        Assert.Equal(david.Name, employeeName);
    }
}
