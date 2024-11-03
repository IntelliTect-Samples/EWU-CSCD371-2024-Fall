namespace GenericsHomework.Tests
{
    public class NodeTests
    {
        [Fact]
        public void Node_SetValue_ReturnTrue()
        {
            // Arrange
            int value = 5;

            // Act
            Node<int> newNode = new Node<int>(value);

            // Assert
            Assert.Equal(value, newNode.Value);

        }
    }
}