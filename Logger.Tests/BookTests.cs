using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Fact]
    public void Constructor_InitializedBook_Success()
    {
        FullName fullName = new("William", "Goldman");
        Book book = new(fullName, "The Princess Bride", "0-345-41826-3");

        Assert.NotNull(book);
        Assert.Equal("William Goldman", book.Author.ToString());
        Assert.Equal("The Princess Bride", book.Title);
        Assert.Equal("0-345-41826-3", book.ISBN);
        Assert.Equal("The Princess Bride written by William Goldman. ISBN: 0-345-41826-3", book.Name);
    }

    [Fact]
    public void Constructor_SetInvalidTitle_ThrowsArgumentNullException()
    {
        FullName fullName = new("William", "Goldman");

        Assert.Throws<ArgumentNullException>(() => new Book(fullName, null!, "0-345-41826-3"));
        Assert.Throws<ArgumentException>(() => new Book(fullName, "", "0-345-41826-3"));
    }

    [Fact]
    public void Constructor_SetInvalidISBN_ThrowsArgumentNullException()
    {
        FullName fullName = new("William", "Goldman");

        Assert.Throws<ArgumentNullException>(() => new Book(fullName, "The Princess Bride", null!));
        Assert.Throws<ArgumentException>(() => new Book(fullName, "The Princess Bride", ""));
    }

    [Fact]
    public void Constructor_GetsGuidAssigned_Success()
    {
        FullName fullName = new("William", "Goldman");
        Book book = new(fullName, "The Princess Bride", "0-345-41826-3");

        Assert.NotEqual(Guid.Empty, ((IEntity)book).Id);
    }

    [Fact]
    public void Constructor_ComparesBooks_Success()
    {
        FullName fullName = new("William", "Goldman");
        Book book1 = new(fullName, "The Princess Bride", "0-345-41826-3");
        Book book2 = new(fullName, "The Princess Bride", "0-345-41826-3");
        Book book3 = book1;

        Assert.NotEqual(book1, book2);
        Assert.Equal(book1, book3);
        Assert.Same(book1, book3);
    }   
}
