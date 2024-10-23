using Xunit;

namespace Logger.Tests;

public class EntityEqualityTests
{
    [Fact]
    public void Book_WithSameTitle_ShouldNotBeEqual()
    {
        // Arrange
        var book1 = new Book("A Painted House");
        var book2 = new Book("A Painted House");

        // Act & Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Book_WithDifferentTitle_ShouldNotBeEqual()
    {
        // Arrange
        var book1 = new Book("A Painted House");
        var book2 = new Book("Into the Wind");

        // Act & Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Students_WithSameName_ShouldNotBeEqual()
    {
        // Arrange
        var student1 = new Student(new FullName("Chris", "J", "Cornell"));
        var student2 = new Student(new FullName("Chris", "J", "Cornell"));

        // Act & Assert
        Assert.NotEqual(student1, student2);
    }
}
