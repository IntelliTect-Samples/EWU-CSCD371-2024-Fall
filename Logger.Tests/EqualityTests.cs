using Xunit;

namespace Logger.Tests;

public class EntityEqualityTests
{
    [Fact]
    public void Book_WithSameTitleAndAuthor_ShouldNotBeEqual()
    {
        // Arrange
        var book1 = new Book("A Painted House", "JK Rowling");
        var book2 = new Book("A Painted House", "JK Rowling");

        // Act & Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Book_WithSameTitleDifferentAuthors_ShouldNotBeEqual()
    {
        // Arrange
        var book1 = new Book("A Painted House", "John Grisham");
        var book2 = new Book("A Painted House", "Steven King");

        // Act & Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Book_WithDifferentTitlesSameAuthor_ShouldNotBeEqual()
    {
        // Arrange
        var book1 = new Book("A Painted House", "John Grisham");
        var book2 = new Book("Into the Wind", "John Grisham");

        // Act & Assert
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void Students_WithSameName_ShouldNotBeSameInstance()
    {
        // Arrange
        var student1 = new Student(new FullName("Chris", "J", "Cornell"), "Senior", "CS");
        var student2 = new Student(new FullName("Chris", "J", "Cornell"), "Senior", "CS");

        // Act & Assert
        Assert.NotSame(student1, student2);
    }

}
