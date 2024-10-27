using CircluarLinkedList;

namespace CircularLinkedList.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_ValidInput_CreatesNode()
    {
        // Act
        Node node = new();

        //Assert
        Assert.NotNull(node);
        Assert.IsType<Node>(node);
    }
}