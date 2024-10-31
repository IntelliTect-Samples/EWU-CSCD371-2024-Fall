using Xunit;

namespace Logger.Tests;

    public class BaseEntityTests
    {
        [Fact]
        public void BaseEntityNameReturnsParsedName()
        {
            // Arrange
            var entity = new MockBaseEntity();

            // Act
            var name = entity.Name;

            // Assert
            Assert.NotNull(name);
            Assert.Equal("Mock Name", name);
        }

        private sealed record class MockBaseEntity : BaseEntity
        {
            public override string ParseName()
            {
                return "Mock Name";
            }
        }
    }
