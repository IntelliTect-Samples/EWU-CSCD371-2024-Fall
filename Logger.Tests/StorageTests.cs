using System;
using Xunit;

namespace Logger.Tests;

public class StorageTests
{

    [Fact]
    public void Constructor_DVC_CreatesStorage()
    {
        //Arrange
        Storage storage = new();
        //Act

        //Assert
        Assert.NotNull(storage);

    }

    #region StudentTests


    [Fact]
    public void Add_Student_AddsToList()
    {
        //Arrange
        Student student = new("School", "first", "last") { GradeLevel = "12th" };
        Storage storage = new();
        //Act
        storage.Add(student);
        //Assert
        Assert.NotNull(student);
        Assert.Equal(storage.Get(student.Id),student);
    }

    [Fact]
    public void Remove_Student_RemovesFromList()
    {
        //Arrange
        Student student = new("School", "first", "last") {GradeLevel = "12th" };
        Storage storage = new();
        //Act

        storage.Add(student);
        storage.Remove(student);
        //Assert
        Assert.False(storage.Contains(student));
    }
    [Fact]
    public void Contains_Student_ReturnsTrue()
    {
        //Arrange
        Student student = new("School", "first", "last") { GradeLevel = "12th" };
        Storage storage = new();
        storage.Add(student);

        //Act


        //Assert
        Assert.True(storage.Contains(student));

    }



    #endregion
}
