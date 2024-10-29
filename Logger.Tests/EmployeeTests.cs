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
    public void Constructor_InitializedEmployee_Success()
    {
        FullName fullName = new("Inigo", "Montoya", "A");
        Employee employee = new(fullName, "Swordsman", "Florin", "Vizzini Group");

        Assert.NotNull(employee);
        Assert.Equal("Inigo A Montoya", employee.Name);
        Assert.Equal("Swordsman", employee.Position);
        Assert.Equal("Florin", employee.Department);
        Assert.Equal("Vizzini Group", employee.Company);
    }

    [Fact]
    public void Constructor_SetNullPosition_ThrowsArgumentNullException()
    {
        FullName fullName = new("Inigo", "Montoya", "A");

        Assert.Throws<ArgumentNullException>(() => new Employee(fullName, null!, "Florin", "Vizzini Group"));
    }

    [Fact]
    public void Constructor_SetNullDepartment_ThrowsArgumentNullException()
    {
        FullName fullName = new("Inigo", "Montoya", "A");

        Assert.Throws<ArgumentNullException>(() => new Employee(fullName, "Swordsman", null!, "Vizzini Group"));
    }

    [Fact]
    public void Constructor_SetNullCompany_ThrowsArgumentNullException()
    {
        FullName fullName = new("Inigo", "Montoya", "A");

        Assert.Throws<ArgumentNullException>(() => new Employee(fullName, "Swordsman", "Florin", null!));
    }

    [Fact]
    public void Constructor_ComparesEmployees_Success()
    {
        FullName fullName = new("Inigo", "Montoya", "A");
        Employee employee1 = new(fullName, "Swordsman", "Florin", "Vizzini Group");
        Employee employee2 = new(fullName, "Swordsman", "Florin", "Vizzini Group");
        Employee employee3 = employee1;

        Assert.NotEqual(employee1, employee2);
        Assert.Equal(employee1, employee3);
        Assert.Same(employee1, employee3);
    }
}
