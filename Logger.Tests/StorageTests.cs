﻿using Xunit;

namespace Logger.Tests;
// TODO: Unit test the Storage class using various entities to ensure that there are no bugs.
public class StorageTests
{
    [Fact]
    public void AddStudent_WithValidStudent_Success()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student
        {
            StudentId = 1,
            StudentName = new FullName("Kevin", "Flannery")
        };

        // Act
        storage.Add(student);

        // Assert
        Assert.True(storage.Contains(student));
    }

    [Fact]
    public void AddEmployee_WithValidEmployee_Success()
    {
        // Arrange
        var storage = new Storage();
        var employee = new Employee
        {
            EmployeeId = 1,
            EmployeeFullName = new FullName("Kevin", "Flannery"),
            EmployeeJobTitle = "Software Engineer"
        };

        // Act
        storage.Add(employee);

        // Assert
        Assert.True(storage.Contains(employee));
    }

    [Fact]
    public void AddBook_WithValidBook_Success()
    {
        // Arrange
        var storage = new Storage();
        var book = new Book
        {
            Title = "Harry Potter 1",
            Author = new FullName("JK", "Rowling")
        };

        // Act
        storage.Add(book);

        // Assert
        Assert.True(storage.Contains(book));
    }

    [Fact]
    public void RemoveStudent_WithValidStudent_Success()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student
        {
            StudentId = 1,
            StudentName = new FullName("Kevin", "Flannery")
        };
        storage.Add(student);

        // Act
        storage.Remove(student);

        // Assert
        Assert.False(storage.Contains(student));
    }   

    [Fact]
    public void RemoveEmployee_WithValidEmployee_Success()
    {
        // Arrange
        var storage = new Storage();
        var employee = new Employee
        {
            EmployeeId = 1,
            EmployeeFullName = new FullName("Kevin", "Flannery"),
            EmployeeJobTitle = "Software Engineer"
        };
        storage.Add(employee);

        // Act
        storage.Remove(employee);

        // Assert
        Assert.False(storage.Contains(employee));
    }

    [Fact]
    public void RemoveBook_WithValidBook_Success()
    {
        // Arrange
        var storage = new Storage();
        var book = new Book
        {
            Title = "Harry Potter 1",
            Author = new FullName("JK", "Rowling")
        };
        storage.Add(book);

        // Act
        storage.Remove(book);

        // Assert
        Assert.False(storage.Contains(book));
    }

    [Fact]
    public void GetStudent_WithValidStudent_Success()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student
        {
            StudentId = 1,
            StudentName = new FullName("Kevin", "Flannery")
        };
        storage.Add(student);

        // Act
        var result = storage.Get(student.Id);

        // Assert
        Assert.Equal(student, result);
    }

    [Fact]
    public void GetEmployee_WithValidEmployee_Success()
    {
        // Arrange
        var storage = new Storage();
        var employee = new Employee
        {
            EmployeeId = 1,
            EmployeeFullName = new FullName("Kevin", "Flannery"),
            EmployeeJobTitle = "Software Engineer"
        };
        storage.Add(employee);

        // Act
        var result = storage.Get(employee.Id);

        // Assert
        Assert.Equal(employee, result);
    }

    [Fact]
    public void GetBook_WithValidBook_Success()
    {
        // Arrange
        var storage = new Storage();
        var book = new Book
        {
            Title = "Harry Potter 1",
            Author = new FullName("JK", "Rowling")
        };
        storage.Add(book);

        // Act
        var result = storage.Get(book.Id);

        // Assert
        Assert.Equal(book, result);
    }

}
