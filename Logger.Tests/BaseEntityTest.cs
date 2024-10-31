using Xunit;

namespace Logger.Tests
{
    public class BaseEntityTests
    {
    //    [Fact]
    //     public void BaseEntity_IdInitialized_ReturnsValidId()
    //     {
    //         // Arrange
    //         var entity = new BaseEntity();

    //         // Act
    //         var id = entity.Id;

    //         // Assert
    //         Assert.NotEqual(Guid.Empty, id);
    //     }

        [Fact]
        public void BaseEntity_Name_ReturnsParsedName()
        {
            // Arrange
            var entity = new MockBaseEntity();

            // Act
            var name = entity.Name;

            // Assert
            Assert.NotNull(name);
            Assert.Equal("Mock Name", name);
        }

        private record class MockBaseEntity : BaseEntity
        {
            public override string ParseName()
            {
                // Implement name parsing logic for testing purposes
                return "Mock Name";
            }
        }
    }
}