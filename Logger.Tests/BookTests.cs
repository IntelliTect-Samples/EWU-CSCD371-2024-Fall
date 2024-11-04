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

        // Assert
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

        // Assert
        Assert.NotNull(newBook);
        Assert.Equal(newBook.ISBN, isbn);
        Assert.Equal("John", newBook.Author.FirstName);
        Assert.Null(newBook.Author.MiddleName);
        Assert.Equal("Doe", newBook.Author.LastName);
        Assert.Equal(newBook.YearPublished, yearPublished);
        Assert.Equal(newBook.Title, title);

    }

    //Consider generating a test for receiving strings for yearPublished and isbn.
}

