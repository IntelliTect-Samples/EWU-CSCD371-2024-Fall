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

    [Theory]
    [InlineData(1)]
    [InlineData("SomeData")]
    [InlineData(null)]
    public void Next_NoSet_ReturnsBaseNode<T>(T? val)
    {
        //Arrange
        Node<T> node = new(val);
        //Act

        //Assert

        Assert.NotNull(node);
        Assert.NotNull(node.Next);
        Assert.Equal(node, node.Next);
        Assert.Same(node, node.Next);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData("SomeData", "21", "thirdValue")]
    [InlineData(45.6, null, 43.5)]
    public void Append_ValidChange_ReturnsExpected<T>(T? val, T? val2, T? val3)
    {
        Node<T> node = new(val);
        node.Append(val3);

        //Act
        node.Append(val2);

        //Assert
        Assert.NotNull(node);
        Assert.NotNull(node.Next);
        Assert.NotNull(node.Next.Next);

        Assert.Equal(val, node.Value);
        Assert.Equal(val2, node.Next.Value);
        Assert.Equal(val3, node.Next.Next.Value);

        Assert.Same(node, node.Next.Next.Next);
    }

    [Theory]
    [InlineData(1, 2, 3, 3, true)]
    [InlineData(1, 2, 3, 13, false)]
    [InlineData("SomeData", "21", "thirdValue", "21", true)]
    [InlineData("SomeData", "21", "thirdValue", "22", false)]
    [InlineData("SomeData", "21", "thirdValue", null, false)]
    [InlineData(null, 32.5, 42.1, null, true)]
    public void Exists_ValidInput_ReturnsTrue<T>(T? val, T? val2, T? val3, T? expectedValue, bool expectedResult)
    {
        Node<T> node = new(val);
        node.Append(val2);
        node.Append(val3);

        //Act
        bool exists = node.Exists(expectedValue);

        //Assert
        Assert.Equal(exists, expectedResult);
    }

    [Theory]
    [InlineData(1, 3, 1)]
    [InlineData("SomeData", "21", "SomeData")]
    [InlineData(null, "data", null)]
    [InlineData("data",null, null)]
    [InlineData(1.0, 2.8, 2.8)]
    public void Append_DuplicateValues_ThrowsException<T>(T? val, T? val2, T? val3)
    {
        //Arrange
        Node<T> node = new(val);
        node.Append(val2);

        //Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append(val3));
    }

    [Theory]
    [InlineData(1, 3, 2)]
    [InlineData("SomeData", "21", "SomeData2")]
    [InlineData(null, "data2", "data")]
    [InlineData("data", null, "t")]
    [InlineData(1.0, 2.8, 2.9)]
    public void Clear_ValidLoop_RemovesNodes<T>(T? val, T? val2, T? val3)
    {
        //Arrange
        Node<T> node = new(val);
        node.Append(val2);
        node.Append(val3);
        Node<T> node2 = node.Next;
        Node<T> node3 = node2.Next;
        //Act
        node.Clear();
        //Assert
        Assert.Equal(node,node.Next);
        Assert.Same(node,node.Next);
        Assert.Same(node2.Next,node2);
        Assert.Same(node3.Next,node3);
        Assert.Equal(node2,node2.Next);
        Assert.Equal(node3,node3.Next);

    }


}