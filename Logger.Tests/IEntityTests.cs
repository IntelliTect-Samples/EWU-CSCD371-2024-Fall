using Moq;
using Xunit;

namespace Logger.Tests;

    public class IEntityTests
    {
        [Fact]
        public void IEntity_ShouldReturnCorrectId()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var mockEntity = new Mock<IEntity>();
            mockEntity.Setup(e => e.Id).Returns(expectedId);

            // Act
            var actualId = mockEntity.Object.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void IEntity_ShouldReturnCorrectName()
        {
            // Arrange
            var expectedName = "Mock Entity";
            var mockEntity = new Mock<IEntity>();
            mockEntity.Setup(e => e.Name).Returns(expectedName);

            // Act
            var actualName = mockEntity.Object.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void IEntity_MultipleInstances_ShouldHaveUniqueIds()
        {
            // Arrange
            var mockEntity1 = new Mock<IEntity>();
            mockEntity1.Setup(e => e.Id).Returns(Guid.NewGuid());

            var mockEntity2 = new Mock<IEntity>();
            mockEntity2.Setup(e => e.Id).Returns(Guid.NewGuid());

            // Act
            var id1 = mockEntity1.Object.Id;
            var id2 = mockEntity2.Object.Id;

            // Assert
            Assert.NotEqual(id1, id2);
        }
    }
