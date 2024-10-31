using Xunit;

namespace Logger.Tests;

public class EntityTests
{
    [Fact]
    public void Book_IdenticalBooks_AreEqual()
    {
        // Arrange
        var book1 = new Book("1984", "George Orwell");
        var book2 = new Book("1984", "George Orwell");
        var book3 = new Book("Brave New World", "Aldous Huxley");

        // Act & Assert
        Assert.Equal(book1.Title, book2.Title);
        Assert.Equal(book1.Author, book2.Author);
        Assert.NotEqual(book1.Title, book3.Title);
        Assert.NotEqual(book1.Author, book3.Author);
    }

    [Fact]
    public void Student_IdenticalStudents_AreEqual()
    {
        // Arrange
        var fullName1 = new FullName("John", "Michael", "Doe");
        var fullName2 = new FullName("John", "Michael", "Doe");
        var student1 = new Student(fullName1, "S001");
        var student2 = new Student(fullName2, "S001");
        var student3 = new Student(fullName1, "S002");

        // Act & Assert
        Assert.Equal(student1.FullName, student2.FullName);
        Assert.Equal(student1.StudentId, student2.StudentId);
        Assert.NotEqual(student1.StudentId, student3.StudentId);
    }

    [Fact]
    public void Employee_IdenticalEmployees_AreEqual()
    {
        // Arrange
        var fullName1 = new FullName("Jane", "Alice", "Smith");
        var fullName2 = new FullName("Jane", "Alice", "Smith");
        var employee1 = new Employee(fullName1, "E001");
        var employee2 = new Employee(fullName2, "E001");
        var employee3 = new Employee(fullName1, "E002");

        // Act & Assert
        Assert.Equal(employee1.FullName, employee2.FullName);
        Assert.Equal(employee1.EmployeeId, employee2.EmployeeId);
        Assert.NotEqual(employee1.EmployeeId, employee3.EmployeeId);
    }
}
