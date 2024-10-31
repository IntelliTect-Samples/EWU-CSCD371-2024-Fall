using Xunit;

namespace Logger.Tests;

public class StorageTests
{
    [Fact]
    public void Add_Employee_ShouldBeSuccessful()
    {
        // Arrange
        var storage = new Storage();
        var employee = new Employee(new FullName("Chris", "J", "Cornell"), "CEO", "BOSS");

        // Act
        storage.Add(employee);
        var containsEmployee = storage.Contains(employee);

        // Assert
        Assert.True(containsEmployee);
    }

    [Fact]
    public void Add_Student_ShouldBeSuccessful()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student(new FullName("Chris", "J", "Cornell"), "Senior", "Computer Science");

        // Act
        storage.Add(student);
        var containsStudent = storage.Contains(student);

        // Assert
        Assert.True(containsStudent);
    }

    [Fact]
    public void Add_Book_ShouldBeSuccessful()
    {
        // Arrange
        var storage = new Storage();
        var book = new Book("A Painted House", "John Grisham");

        // Act
        storage.Add(book);
        var containsBook = storage.Contains(book);

        // Assert
        Assert.True(containsBook);
    }

    [Fact]
    public void Remove_Student_ShouldBeSuccessful()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student(new FullName("Chris", "J", "Cornell"), "Senior", "Computer Science");

        // Act
        storage.Add(student);
        storage.Remove(student);
        var containsStudent = storage.Contains(student);

        // Assert
        Assert.False(containsStudent);
    }

    [Fact]
    public void Remove_Book_ShouldBeSuccessful()
    {
        // Arrange
        var storage = new Storage();
        var book = new Book("To Kill a Mockingbird", "Harper Lee");

        // Act
        storage.Add(book);
        storage.Remove(book);
        var containsBook = storage.Contains(book);

        // Assert
        Assert.False(containsBook);
    }

    [Fact]
    public void Get_StudentById_ShouldReturnCorrectStudent()
    {
        // Arrange
        var storage = new Storage();
        var student = new Student(new FullName("Chris", "J", "Cornell"), "Senior", "Computer Science");

        // Act
        storage.Add(student);
        var retrievedStudent = storage.Get(student.Id);

        // Assert
        Assert.Equal(student, retrievedStudent);
    }
}
