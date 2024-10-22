using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void StudentCreation_NotNull_ReturnsNotNull()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student = new(fullName);

        //Assert
        Assert.NotNull(student);
    }

    [Fact]
    public void StudentCreation_IsType_ReturnsStudentType()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student = new(fullName);

        //Assert
        Assert.IsType<Student>(student);
    }

    [Fact]
    public void StudentCreation_ChecksGuid_GuidExists()
    {
        //Act
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student = new(fullName);

        //Assert
        Assert.NotEqual(Guid.Empty, student.Id);

    }

    [Fact]
    public void StudentCreation_ChecksName_NamesExists()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");

        //Act
        Student student = new(fullName);
        string name = student.Name;

        //Assert
        Assert.NotNull(name);
    }

    [Fact]
    public void StudentCreation_ChecksName_NamesEqual()
    {
        //Arrange
        FullName fullName = new("Inigo", "Montoya", "Ella");

        //Act
        Student student = new(fullName);
        string name = student.Name;

        //Assert
        Assert.Equal("Inigo Ella Montoya", name);
    }
}
