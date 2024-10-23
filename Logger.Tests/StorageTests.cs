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
        Student student = new("StudentID-12345", "School", "first", "last") { GradeLevel = "12th" };
        Storage storage = new();

        //Act
        storage.Add(student);

        //Assert
        Assert.NotNull(student);
        Assert.Equal(storage.Get(((IEntity)student).Id),student);
    }

    [Fact]
    public void Remove_Student_RemovesFromList()
    {
        //Arrange
        Student student = new("StudentID-12345", "School", "first", "last") {GradeLevel = "12th" };
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
        Student student = new("StudentID-12345", "School", "first", "last") { GradeLevel = "12th" };
        Storage storage = new();
        storage.Add(student);

        //Act

        //Assert
        Assert.True(storage.Contains(student));

    }
    [Fact]
    public void Get_Student_ReturnsStudent()
    {
        //Arrange
        Student student = new("StudentID-12345", "School", "first", "last") { GradeLevel = "12th" };
        Storage storage = new();
        storage.Add(student);
        Guid studentId = ((IEntity)student).Id;

        //Act
        IEntity? resultantStudent = storage.Get(studentId);

        //Assert
        Assert.NotNull(resultantStudent);
        Assert.IsType<Student>(resultantStudent);
        Assert.Equal(student,resultantStudent);
    }

    #endregion

    #region BookTests

    [Fact]
    public void Add_Book_AddsToList()
    {
        //Arrange
        Book book = new("IsbnNumber", 1956, "SomeTitle", "AuthorsFirst", "AuthorsLast");
        Storage storage = new();

        //Act
        storage.Add(book);

        //Assert
        Assert.NotNull(book);
        Assert.Equal(storage.Get(((IEntity)book).Id),book);
    }

    [Fact]
    public void Remove_Book_RemovesFromList()
    {
        //Arrange
        Book book = new("IsbnNumber", 1956, "SomeTitle", "AuthorsFirst", "AuthorsLast");
        Storage storage = new();

        //Act
        storage.Add(book);
        storage.Remove(book);

        //Assert
        Assert.False(storage.Contains(book));
    }
    [Fact]
    public void Contains_Book_ReturnsTrue()
    {
        //Arrange
        Book book = new("IsbnNumber", 1956, "SomeTitle", "AuthorsFirst", "AuthorsLast");
        Storage storage = new();
        storage.Add(book);

        //Act

        //Assert
        Assert.True(storage.Contains(book));

    }
    [Fact]
    public void Get_Book_ReturnsBook()
    {
        //Arrange
        Book book = new("IsbnNumber", 1956, "SomeTitle", "AuthorsFirst", "AuthorsLast");
        Storage storage = new();
        storage.Add(book);
        Guid bookId = ((IEntity)book).Id;
        //Act
        IEntity? resultantBook = storage.Get(bookId);

        //Assert
        Assert.NotNull(book);
        Assert.IsType<Book>(book);
        Assert.Equal(book, resultantBook);
    }
    #endregion

    #region StudentTests


    [Fact]
    public void Add_Employee_AddsToList()
    {
        //Arrange
        Employee employee = new("employeeID", "position", "first", "last");
        Storage storage = new();

        //Act
        storage.Add(employee);

        //Assert
        Assert.NotNull(employee);
        Assert.Equal(storage.Get(((IEntity)employee).Id), employee);
    }

    [Fact]
    public void Remove_Employee_RemovesFromList()
    {
        //Arrange
        Employee employee = new("employeeID", "position", "first", "last");
        Storage storage = new();

        //Act
        storage.Add(employee);
        storage.Remove(employee);

        //Assert
        Assert.False(storage.Contains(employee));
    }
    [Fact]
    public void Contains_Employee_ReturnsTrue()
    {
        //Arrange
        Employee employee = new("employeeID", "position", "first", "last");
        Storage storage = new();
        storage.Add(employee);

        //Act

        //Assert
        Assert.True(storage.Contains(employee));

    }
    [Fact]
    public void Get_Employee_ReturnsStudent()
    {
        //Arrange
        Employee employee = new("employeeID", "position", "first", "last");
        Storage storage = new();
        storage.Add(employee);
        Guid studentId = ((IEntity)employee).Id;

        //Act
        IEntity? resultantEmployee = storage.Get(studentId);

        //Assert
        Assert.NotNull(resultantEmployee);
        Assert.IsType<Employee>(resultantEmployee);
        Assert.Equal(employee, resultantEmployee);

    }



    #endregion
}
