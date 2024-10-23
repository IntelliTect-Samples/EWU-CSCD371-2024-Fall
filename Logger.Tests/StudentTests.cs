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
        // Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student = new(fullName);

        // Act
        var studentEntity = (IEntity)student;


        // Assert
        Assert.NotEqual(Guid.Empty, studentEntity.Id);

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

    [Fact]
    public void Equality_NameEquality_ReturnsTrue()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student1 = new(fullName);
        Student student2 = new(fullName);

        //Act
        bool result = student1.Name.Equals(student2.Name);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void Equality_GuidNotEqual_ReturnsFalse()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student1 = new(fullName);
        Student student2 = new(fullName);
        IEntity studentEntity1 = (IEntity)student1;
        IEntity studentEntity2 = (IEntity)student2;

        //Act
        bool result = studentEntity1.Id.Equals(studentEntity2.Id);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void Equality_StudentNotEqual_ReturnsFalse()
    {
        //Arrange
        FullName fullName = new("Inigo", "Ella", "Montoya");
        Student student1 = new(fullName);
        Student student2 = new(fullName);

        //Act
        bool result = student1.Equals(student2);

        //Assert
        Assert.False(result);
    }
}
