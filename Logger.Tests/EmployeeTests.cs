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
        Employee employee = new(fullName, "Test Position");

        //Assert
        Assert.NotNull(employee);
    }

    [Fact]
    public void EmployeeCreation_IsType_ReturnsEmployeeType()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName, "Test Position");

        //Assert
        Assert.IsType<Employee>(employee);
    }

    [Fact]
    public void EmployeeCreation_ChecksGuid_GuidExists()
    {
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName, "Test Position");

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
        Employee employee = new(fullName, "Test Position");
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
        Employee employee = new(fullName, "Test Position");
        string name = employee.Name;

        //Assert
        Assert.Equal("Inigo Ella Montoya", name);
    }

    [Fact]
    public void Employee_UpdatePosition_UpdatesSuccessfully()
    {
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName, "Junior Developer")
        {
            // Act
            Position = "Senior Developer"
        };

        // Assert
        Assert.Equal("Senior Developer", employee.Position);
    }

    [Fact]
    public void EmployeeCreation_WithPosition_SetsPositionCorrectly()
    {
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");

        // Act
        Employee employee = new(fullName, "Software Engineer");

        // Assert
        Assert.Equal("Software Engineer", employee.Position);
    }

    [Fact]
    public void Employee_SetInvalidPosition_ThrowsArgumentException()
    {
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new(fullName, "Junior Developer");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => employee.Position = "");
    }
}
