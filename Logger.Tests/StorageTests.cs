using System.Xml.Linq;
using Xunit;

namespace Logger.Tests;
    public class StorageTests
    {
    [Fact]
    public void EmployeeStorage_AddEntitiesToStorage_ReturnsTrue()
    {
        // Arrange
        Storage newStorage = new();
        Employee john = new("John Middle Doe", "Coding Dojo", "Manager", 319172);


        //Act
        newStorage.Add(john);


        // Act & Assess
        Assert.NotNull(newStorage);
        Assert.True(newStorage.Contains(john));
    }

    [Fact]
    public void BookStorage_AddEntitiesToStorage_ReturnsTrue()
    {
        // Arrange
        Storage newStorage = new();
        Book book = new("The Book", "The Author", 2022, 1234567890);

        //Act

        newStorage.Add(book);

        // Act & Assess
        Assert.NotNull(newStorage);
        Assert.True(newStorage.Contains(book));
    }

    [Fact]
    public void StudentStorage_AddEntitiesToStorage_ReturnsTrue()
    {
        // Arrange
        Storage newStorage = new();
        Student david = new("David Middle Moore", "Rogers High School", 319171);


        //Act
        newStorage.Add(david);

        // Act & Assess
        Assert.NotNull(newStorage);
        Assert.True(newStorage.Contains(david));
    }


    [Fact]
    public void BookStorage_AddAndRemoveEntitiesFromStorage_ReturnsFalse ()
    {
        // Arrange
        Storage newStorage = new();
        Book book = new("The Book", "The Author", 2022, 1234567890);
        newStorage.Add(book);

        //Act
        newStorage.Remove(book);

        // Act & Assess
        Assert.False(newStorage.Contains(book));
    }

    [Fact]
    public void EmployeeStorage_AddAndRemoveEntitiesFromStorage_ReturnsFalse()
    {
        // Arrange
        Storage newStorage = new();
        Employee john = new("John Middle Doe", "Coding Dojo", "Manager", 319172);
        newStorage.Add(john);

        //Act
        newStorage.Remove(john);


        // Act & Assess
        Assert.False(newStorage.Contains(john));
    }

    [Fact]
    public void StudentStorage_AddAndRemoveEntitiesFromStorage_ReturnsFalse()
    {
        // Arrange
        Storage newStorage = new();
        Student david = new("David Middle Moore", "Rogers High School", 319171);
        newStorage.Add(david);


        //Act
        newStorage.Remove(david);

        // Act & Assess
        Assert.False(newStorage.Contains(david));

    }
    //Add test for getMethod, double check Guid Id vs S/E.ID
}

