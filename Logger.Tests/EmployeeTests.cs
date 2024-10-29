﻿using Xunit;   

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
        Assert.Equal(david.EmployeeID, employeeID);
        Assert.Equal("David", david.EmployeeName.FirstName);
        Assert.Equal("Middle", david.EmployeeName.MiddleName);
        Assert.Equal("Moore", david.EmployeeName.LastName);
        Assert.Equal(david.EmployeeRole, employeeRole);
        Assert.Equal(david.Employer, employer);
        Assert.Equal(david.Name, employeeName);
    }
}
