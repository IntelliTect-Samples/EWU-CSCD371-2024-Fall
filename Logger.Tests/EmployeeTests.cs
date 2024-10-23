using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class EmployeeTests
{
    [Fact]
    public void EmployeeCreation_NotNull_ReturnsNotNull()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName);

        //Assert
        Assert.NotNull(employee);
    }

    [Fact]
    public void EmployeeCreation_IsType_ReturnsEmployeeType()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName);

        //Assert
        Assert.IsType<Employee>(employee);
    }

    [Fact]
    public void EmployeeCreation_ChecksGuid_GuidExists()
    {
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName);

        // Act 
        var employeeEntity = (IEntity)employee;
        Guid employeeGuid = employeeEntity.Id; 

        // Assert
        Assert.NotEqual(Guid.Empty, employeeGuid);
    }

    [Fact]
    public void EmployeeCreation_ChecksName_NamesExists()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");

        //Act
        Employee employee = new(fullName);
        string name = employee.Name;

        //Assert
        Assert.NotNull(name);
    }

    [Fact]
    public void EmployeeCreation_ChecksName_NamesEqual()
    {
        //Arrange
        FullName fullName = new("Inigo", "Montoya", "Ella");

        //Act
        Employee employee = new(fullName);
        string name = employee.Name;

        //Assert
        Assert.Equal("Inigo Ella Montoya", name);
    }

}
