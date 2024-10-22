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
        Student student = new();

        //Assert
        Assert.NotNull(student);
    }

    [Fact]
    public void StudentCreation_IsType_ReturnsStudentType()
    {
        //Act
        Student student = new();

        //Assert
        Assert.IsType<Student>(student);
    }

    [Fact]
    public void StudentCreation_ChecksGuid_GuidExists()
    {
        //Act
        Student student = new();

        //Assert
        Assert.NotEqual(Guid.Empty, student.Id);

    }

    [Fact]
    public void StudentCreation_ChecksName_NameExists()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");

        //Act
        Student student = new(fullName);
        string name = student.Name;

        //Assert
        Assert.Equal("Inigo Ella Montoya", name);

    }
}
