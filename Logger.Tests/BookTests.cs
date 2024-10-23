using Xunit;

namespace Logger.Tests;

public class BookTests
{
    //[Fact]
    //public void Author_SetNull_ArgumentNullException()
    //{
    //    // Arrange
    //    Book book = new Book();
    //    // Act
        
    //    // Assert
    //    Assert.Throws<ArgumentNullException>(() => book.Author = new FullName(null!, null!));
    //}

    [Fact]
    public void Author_SetValid_Success()
    {
        // Arrange
        Book book = new Book();
        book.Author = new FullName("JK", "Rowling");
        
        // Act

        // Assert
        Assert.Equal(new FullName("JK", "Rowling"), book.Author);
    }

    [Fact]
    public void Title_SetValid_Success()
    {
        // Arrange
        Book book = new Book();
        book.Title = "Harry Potter 1";
        // Act

        // Assert
        Assert.Equal("Harry Potter 1", book.Title);
    }

    [Fact]
    public void Title_SetNull_ArgumentNullException()
    {
        // Arrange
        Book book = new Book();
        
        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => book.Title = null!);

    }

    [Fact]
    public void Title_SetEmpty_ArgumentNullException()
    {
        // Arrange
        Book book = new Book();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => book.Title = "");
    }

    [Fact]
    public void Name_SetValid_Success()
    {
        // Arrange
        Book book = new Book();
        //book.Title = "Harry Potter 1";
        //book.Author = new FullName("JK", "Rowling");
        book.Name = "Harry Potter 1 by: JK Rowling";
        // Act

        // Assert
        Assert.Equal("Harry Potter 1 by: JK Rowling", book.Name);
    }

    [Fact]
    public void Name_SetNull_ArgumentNullException()
    {
        // Arrange
        Book book = new Book();

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => book.Name = null!);
    }

    [Fact]
    public void Name_SetEmpty_ArgumentException()
    {
        // Arrange
        Book book = new Book();

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => book.Name = "");
    }

    [Fact]
    public void Name_SetInvalidAuthor_ArgumentException()
    {
        // Arrange
        Book book = new Book();
        
        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => book.Name = "Harry Potter 1 by: JK ");
    }


}
