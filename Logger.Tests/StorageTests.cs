using System;
using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void constructor_DVC_CreatesStorage()
    {
        //Arrange
        Storage storage = new();
        //Act

        //Assert
        Assert.NotNull(storage);

    }


    [Fact]
    public void Add_Student_AddsToList()
    {
        //Arrange
        Student student = new Student("School", "first", "last");
        Storage storage = new();
        //Act
        storage.Add(student);
        //Assert
        Assert.NotNull(student);
        Assert.Equal(storage.Get(student.Id),student);
    }
}
