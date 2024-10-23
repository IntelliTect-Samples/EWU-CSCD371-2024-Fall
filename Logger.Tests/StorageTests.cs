using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void Contains_Entity_ShouldReturnTrueIfEntityIsInStorage()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("Inigo", "Montoya", "Ella"));
        storage.Add(student);

        // Act
        bool result = storage.Contains(student);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Add_Entity_ShouldAddEntityToStorage()
    {
        // Arrange
        Storage storage = new();
        Employee employee = new(new FullName("Inigo", "Montoya", "Ella"));

        // Act
        storage.Add(employee);

        // Assert
        Assert.True(storage.Contains(employee));
    }


    [Fact]
    public void Remove_Entity_ShouldRemoveEntityFromStorage()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("Inigo", "Montoya", "Ella"));
        storage.Add(student);

        // Act
        storage.Remove(student);

        // Assert
        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Get_EntityById_ShouldReturnCorrectEntity()
    {
        // Arrange
        Storage storage = new();
        Student student = new(new FullName("John", "A.", "Doe"));

        // Add the student to storage
        storage.Add(student);

        // Act
        // Cast the student to IEntity to access the explicit Id
        var studentId = ((IEntity)student).Id;
        var result = storage.Get(studentId);

        // Assert
        Assert.Equal(student, result);
    }
}
