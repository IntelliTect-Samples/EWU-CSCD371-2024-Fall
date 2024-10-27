using CircluarLinkedList;

namespace CircularLinkedList.Tests;

public class NodeTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(11231.2)]
    [InlineData("MyDataValue")]
    [InlineData(null)]
    public void Constructor_ValidInput_CreatesValidNode<T>(T value)
    {
       

        // Act
        Node<T> node = new(value);

        //Assert
        Assert.NotNull(node);
        Assert.IsType<Node<T>>(node);
        Assert.Equal(value, node.Value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData("SomeData")]
    [InlineData(null)]
    public void ToString_ValidCall_ReturnsString<T>(T? val)
    {
        //Arrange
        Node<T> node = new(val);
        //Act

        //Assert
        Assert.NotNull(node);
        Assert.Equal(val?.ToString(), node.ToString());
    }

  
    }

}