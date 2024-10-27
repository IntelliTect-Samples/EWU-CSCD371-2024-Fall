using CircluarLinkedList;

namespace CircularLinkedList.Tests;

public class NodeTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(11231.2)]
    [InlineData("MyDataValue")]
    public void Constructor_ValidInput_CreatesValidNode<T>(T value)
    {
       

        // Act
        Node<T> node = new(value);

        //Assert
        Assert.NotNull(node);
        Assert.IsType<Node<T>>(node);
        Assert.Equal(value, node.Value);
    }
}