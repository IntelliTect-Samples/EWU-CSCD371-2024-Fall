using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Node_HaveValue_ReturnsValue()
    {
        Node<int> node = new(5);
        Assert.Equal(5, node.Value);
    }

    [Fact]
    public void Node_HaveNext_ReturnsNext()
    {
        Node<int> node = new(5);
        Node<int> nextNode = new(10);
        node.Next = nextNode;
        Assert.Equal(nextNode, node.Next);
    }

    [Fact]
    public void ToString_ReturnCorrectString_Success()
    {
        Node<int> node = new(5);
        Assert.Equal("5", node.ToString());
        Node<string> node2 = new("Hello");
        Assert.Equal("Hello", node2.ToString());
    }

    [Fact]
    public void ToString_ReturnNullString_Success()
    {
        Node<string?> node = new(null);
        Assert.Null(node.ToString());
    }

    [Fact]
    public void Append_InsertValue_Success()
    {
        Node<int> node = new(5);
        var newNode = node.Append(10);
        Assert.Equal(newNode, node.Next);
        Assert.Equal(node, newNode.Next);

    }

    [Fact]
    public void Append_DuplicateValue_ThrowsException()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.Throws<InvalidOperationException>(() => node.Append(2));
    }

    [Fact]
    public void Exists_ValueExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.True(node.Exists(2));
    }

    [Fact]
    public void Exists_ValueDoesNotExists_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.False(node.Exists(4));
    }

    [Fact]
    public void Clear_RemoveAllNodes_Success()
    {
        Node<int> node1 = new(1);
        var node2 = node1.Append(2);
        var node3 = node2.Append(3);
        node1.Clear();
        Assert.Equal(node1, node1.Next);
        Assert.Equal(node2, node3.Next);
    }

    [Fact]
    public void Clear_RemoveSingleNode_Success()
    {
        Node<int> node = new(1);
        node.Clear();
        Assert.Equal(node, node.Next);
    }

}
