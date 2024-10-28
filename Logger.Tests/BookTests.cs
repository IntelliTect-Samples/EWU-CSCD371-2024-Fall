using Xunit;

namespace Logger.Tests;
    public class BookTests
    {
        [Fact]
        public void Book_CreationWithValidData_SuccessfullyCreatesInstance()
        {
            // Arrange
            var author = new FullName("Joanne", "K.", "Rowling");
            var isbn = "9780747532743"; // Harry Potter ISBN

            // Act
            var book = new Book("Harry Potter and the Philosopher's Stone", author, "Fantasy", "Bloomsbury", 1997, isbn);

            // Assert
            Assert.NotNull(book);
            Assert.Equal("Harry Potter and the Philosopher's Stone", book.Title);
            Assert.Equal(author, book.Author);
            Assert.Equal("Fantasy", book.Genre);
            Assert.Equal("Bloomsbury", book.Publisher);
            Assert.Equal(1997, book.Year);
            Assert.Equal(isbn, book.Isbn);
        }

        [Fact]
        public void Book_AssignedIdUponCreation_IdIsNotEmpty()
        {
            // Arrange
            var author = new FullName("George", "R.R.", "Martin");
            var isbn = "9780553573404"; // Game of Thrones ISBN
            var book = new Book("A Game of Thrones", author, "Fantasy", "Bantam Books", 1996, isbn);

            // Act 
            var bookEntity = (IEntity)book;
            var bookId = bookEntity.Id;

            // Assert
            Assert.NotEqual(Guid.Empty, bookId);
        }

        [Fact]
        public void Book_NameWithMiddleName_ReturnsFullNameIncludingMiddleName()
        {
            // Arrange
            var author = new FullName("Frank", "Patrick", "Herbert");
            var isbn = "9780441172719"; // Dune ISBN
            var book = new Book("Dune", author, "Science Fiction", "Chilton Books", 1965, isbn);

            // Act
            var result = book.Name;

            // Assert
            Assert.Equal("Frank Patrick Herbert", result);
        }

        [Fact]
        public void Book_NameWithoutMiddleName_ReturnsFullNameWithoutMiddleName()
        {
            // Arrange
            var author = new FullName("Andrzej", null, "Sapkowski");
            var isbn = "9780316029186"; // The Witcher ISBN
            var book = new Book("The Witcher: The Last Wish", author, "Fantasy", "Gollancz", 2007, isbn);

            // Act
            var result = book.Name;

            // Assert
            Assert.Equal("Andrzej Sapkowski", result);
        }

         [Fact]
        public void Book_ThrowsArgumentNullException_WhenAuthorIsNull()
        {
            // Arrange
            FullName? author = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Book("Harry Potter and the Philosopher's Stone", author!, "Fantasy", "Bloomsbury", 1997, "9780747532743"));
            Assert.Equal("Value cannot be null. (Parameter 'Author')", exception.Message);
        }

        [Fact]
        public void Book_ThrowsArgumentException_WhenTitleIsNullOrEmpty()
        {
            // Arrange
            var author = new FullName("Joanne", "K.", "Rowling");

            // Act & Assert
            var exceptionEmptyTitle = Assert.Throws<ArgumentException>(() => new Book(string.Empty, author, "Fantasy", "Bloomsbury", 1997, "9780747532743"));
            Assert.Equal("Title cannot be null or empty. (Parameter 'Title')", exceptionEmptyTitle.Message);
            
        }

        [Fact]
        public void Book_ThrowsArgumentException_WhenIsbnIsNullOrEmpty()
        {
            // Arrange
            var author = new FullName("George", "R.R.", "Martin");

            // Act & Assert
            var exceptionEmptyIsbn = Assert.Throws<ArgumentException>(() => new Book("A Game of Thrones", author, "Fantasy", "Bantam Books", 1996, string.Empty));
            Assert.Equal("ISBN cannot be null or empty. (Parameter 'isbn')", exceptionEmptyIsbn.Message);
            
        }

        [Fact]
        public void Book_ThrowsArgumentNullException_WhenPublisherIsNull()
        {
            // Arrange
            var author = new FullName("Frank", "Patrick", "Herbert");

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Book("Dune", author, "Science Fiction", null!, 1965, "9780441172719"));
            Assert.Equal("Value cannot be null. (Parameter 'publisher')", exception.Message);
        }

        [Fact]
        public void Book_Equality_AssertsTrue()
        {
            //Arrange
            FullName author = new FullName("Frank", "Patrick", "Herbert");
            string isbn = "9780441172719"; // Dune ISBN
            Book book1 = new Book("Dune", author, "Science Fiction", "Chilton Books", 1965, isbn);
            Book book2 = book1 with {};
            
            //Act
            bool result = book1.Equals(book2);
            
            //Assert
            Assert.True(result);
        }
        
        [Fact]
        public void Book_ReferenceEquality_AssertsFalse()
        {
            //Arrange
            FullName author = new FullName("Rick", null,"Yancey"); 
            string isbn = "9780399162411"; // The 5th Wave ISBN
            Book book1 = new Book("The 5th Wave", author, "Science Fiction", 
                "G.P. Putnam's Sons", 2013, isbn);
          
            //Act
            bool result = ReferenceEquals(book1, book1 with {});
            //Assert
            Assert.False(result);
        }
        
    }

