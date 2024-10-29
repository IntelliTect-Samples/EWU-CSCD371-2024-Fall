using System.Xml.Linq;
using Xunit;

namespace Logger.Tests;
    public class StorageTests
    {
    [Fact]
    public void StudentEmployeeBookStorage_AddEntitiesToStorage_ReturnsTrue()
    {
        // Arrange
        Storage newStorage = new();
        Student david = new("David Middle Moore", "Rogers High School", 319171);
        Employee john = new("John Middle Doe", "Coding Dojo", "Manager", 319172);
        Book book = new("The Book", "The Author", 2022, 1234567890); 

        //Act
        newStorage.Add(david);
        newStorage.Add(john);
        newStorage.Add(book);

        // Act & Assess
        Assert.NotNull(newStorage);
        Assert.True(newStorage.Contains(david));
        Assert.True(newStorage.Contains(john));
        Assert.True(newStorage.Contains(book));
    }

    [Fact]
    public void StudentEmployeeBookStorage_AddAndRemoveEntitiesFromStorage_ReturnsFalse ()
    {
        // Arrange
        Storage newStorage = new();
        Student david = new("David Middle Moore", "Rogers High School", 319171);
        Employee john = new("John Middle Doe", "Coding Dojo", "Manager", 319172);
        Book book = new("The Book", "The Author", 2022, 1234567890);
        newStorage.Add(david);
        newStorage.Add(john);
        newStorage.Add(book);

        //Act
        newStorage.Remove(david);
        newStorage.Remove(john);
        newStorage.Remove(book);

        // Act & Assess
        Assert.False(newStorage.Contains(david));
        Assert.False(newStorage.Contains(john));
        Assert.False(newStorage.Contains(book));
    }

}

