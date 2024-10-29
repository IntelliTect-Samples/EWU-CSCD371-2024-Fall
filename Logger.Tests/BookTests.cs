using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Fact]
    public void BookRecord_ValidData_CreatesRecord()
    {
        // Arrange
        var authorName = "John Middle Doe";
        var title = "Test Book";
        var yearPublished = 2022;
        var isbn = 1234567890;

        //Act
        Book newBook = new(title, authorName, yearPublished, isbn);

        // Act & Assess
        Assert.NotNull(newBook);
        Assert.Equal(newBook.ISBN, isbn);
        Assert.Equal("John", newBook.Author.FirstName);
        Assert.Equal("Middle", newBook.Author.MiddleName);
        Assert.Equal("Doe", newBook.Author.LastName);
        Assert.Equal(newBook.YearPublished, yearPublished);
        Assert.Equal(newBook.Title, title);

    }

    [Fact]
    public void BookRecord_ValidDataNoMiddle_CreatesRecordNullMiddleName()
    {
        // Arrange
        var authorName = "John Doe";
        var title = "Test Book";
        var yearPublished = 2022;
        var isbn = 1234567890;

        //Act
        Book newBook = new(title, authorName, yearPublished, isbn);

        // Act & Assess
        Assert.NotNull(newBook);
        Assert.Equal(newBook.ISBN, isbn);
        Assert.Equal("John", newBook.Author.FirstName);
        Assert.Null(newBook.Author.MiddleName);
        Assert.Equal("Doe", newBook.Author.LastName);
        Assert.Equal(newBook.YearPublished, yearPublished);
        Assert.Equal(newBook.Title, title);

    }

    [Fact]
    public void ConstructorTest_ValidData_CreatesRecord()
    {
        // Arrange & Act
        Book newBook = new("Harry Potter", "J.K. Rowling", 2000, 33-0987654);

        // Act & Assess
        Assert.NotNull(newBook);
        Assert.Equal(expected: 33 - 0987654, actual: newBook.ISBN);
        Assert.Equal("J.K.", newBook.Author.FirstName);
        Assert.Null(newBook.Author.MiddleName);
        Assert.Equal("Rowling", newBook.Author.LastName);
        Assert.Equal(2000, newBook.YearPublished);
        Assert.Equal("Harry Potter", newBook.Title);

    }

    //Consider generating a test for receiving strings for yearPublished and isbn.
}

