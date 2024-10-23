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
        Employee employee = new();

        //Assert
        Assert.NotNull(employee);
    }

    [Fact]
    public void EmployeeCreation_IsType_ReturnsStudentType()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new();

        //Assert
        Assert.IsType<Employee>(employee);
    }

    [Fact]
    public void EmployeeCreation_ChecksGuid_GuidExists()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Employee employee = new();

        //Assert
        Assert.NotEqual(Guid.Empty, employee.Id);

    }
}
