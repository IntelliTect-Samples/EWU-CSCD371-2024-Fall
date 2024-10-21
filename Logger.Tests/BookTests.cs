using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Theory]
    [InlineData("ISBN", "Author", 1998, "Title")]
    public void Constructor_AllParamaters_MakesRecord(string isbn, string author, int publicationYear, string title)
    {
        //Arrange
        string expectedIsbn = "ISBN";
        string expectedAuthor = "Author";
        int expectedPublicationYear = 1998;
        string expectedTitle = "Title";

        //Act
        Book book = new() { ISBN = isbn, Author = author, PublicationYear = publicationYear, Title = title };

        //Assert
        Assert.NotNull(book);
        Assert.Equal(book.ISBN, expectedIsbn);
        Assert.Equal(book.Author, expectedAuthor);
        Assert.Equal(book.PublicationYear, expectedPublicationYear);
        Assert.Equal(book.Title, expectedTitle);
    }

    [Theory]
    [InlineData(null, "Author", 1998, "Title")]
    [InlineData("ISBN", null, 1998, "Title")]
    [InlineData("ISBN", "Author", 0, "Title")]
    [InlineData("ISBN", "Author", 1998, null)]
    public void Constructor_BadParamaters_ThrowsException(string? isbn, string? author, int publicationYear, string? title)
    {
        //Arrange

        //Act

        //Assert
        Assert.ThrowsAny<ArgumentException>(() => new Book() { ISBN = isbn!, Author = author!, PublicationYear = publicationYear,Title = title! });
    }
}