using Xunit;

namespace Logger.Tests;
    public class StorageTest
    {
        [Fact]
        public void Storage_AddNewStudent_Successful()
        {
            // Arrange  
            Storage storage = new();
            IEntity student = new Student("John", "Doe", "Smith",
                "john.doe@example.com", "Eastern", 2024, "Computer Science", "1234567890", 20, "10-05-2004");

            // Act  
            storage.Add(student);

            // Assert  
            Assert.True(storage.Contains(student));
        }

        [Fact]
        public void Storage_RemoveEntity_Successful()
        {
            // Arrange
            Storage storage = new();
            IEntity student = new Student("Joe", "Deer", "Danson",
                "joedeer@ewu.edu", "Eastern", 2024, "Arts", "2345872390", 34, "10-05-1990");
            storage.Add(student);

            // Act
            storage.Remove(student);

            // Assert
            Assert.False(storage.Contains(student));
        }

        [Fact]
        public void Storage_Contains_ReturnsTrueForExistingEntity()
        {
            // Arrange
            Storage storage = new();
            IEntity student = new Student("Ally", "Mae", "Jones",
                "ally.jones@ewu.edu", "Eastern", 2025, "Biology", "3456789012", 22, "03-11-2001");
            storage.Add(student);

            // Act
            var result = storage.Contains(student);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Storage_Contains_ReturnsFalseForNonExistentEntity()
        {
            // Arrange
            Storage storage = new();
            IEntity student = new Student("Sam", "Lee", "Parker",
                "sam.parker@ewu.edu", "Eastern", 2023, "Physics", "5678901234", 24, "08-15-1999");

            // Act
            var result = storage.Contains(student);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Storage_Get_ReturnsEntityForExistingId()
        {
            // Arrange
            Storage storage = new();
            var student = new Student("Chris", "David", "Evans",
                "chris.evans@ewu.edu", "Eastern", 2024, "Chemistry", "6789012345", 21, "05-13-2002");
            storage.Add(student);

            // Act
            var retrievedEntity = storage.Get(student.Id);

            // Assert
            Assert.NotNull(retrievedEntity);
            Assert.Equal(student, retrievedEntity);
        }
        
        [Fact]
        public void Storage_Get_ReturnsNullForNonExistentEntity()
        {
            // Arrange
            Storage storage = new();
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var retrievedEntity = storage.Get(nonExistentId);

            // Assert
            Assert.Null(retrievedEntity);
        }

        [Fact]
        public void Storage_Get_ReturnsNullAfterEntityIsRemoved()
        {
            // Arrange
            Storage storage = new();
            IEntity student = new Student("Lily", "Rose", "Thompson",
                "lily.thompson@ewu.edu", "Eastern", 2022, "History", "7890123456", 23, "09-25-2000");
            storage.Add(student);
            storage.Remove(student);

            // Act
            var retrievedEntity = storage.Get(((IEntity)student).Id);

            // Assert
            Assert.Null(retrievedEntity);
        }
    }

