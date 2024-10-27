using CircluarLinkedList;

namespace CircularLinkedList.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_ValidInput_CreatesValidNode()
    {
        // Act
        Node<int> node = new(12);

        //Assert
        Assert.NotNull(node);
        Assert.IsType<Node<int>>(node);
        Assert.Equal(12, node.Value);
    }
}