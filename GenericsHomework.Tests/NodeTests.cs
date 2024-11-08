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

    //ICollection<T> implementation tests

    [Fact]
    public void Count_ReturnsCorrectCount_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.Equal(3, node.Count);
    }

    [Fact]
    public void IsReadOnly_ReturnsFalse_Success()
    {
        Node<int> node = new(1);
        Assert.False(node.IsReadOnly);
    }

    [Fact]
    public void Add_InsertValue_Success()
    {
        Node<int> node = new(1);
        node.Add(2);
        Assert.True(node.Exists(2));
    }

    [Fact]
    public void Contains_ValueExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.Contains(2, node);
    }

    [Fact]
    public void Contains_ValueDoesNotExists_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.DoesNotContain(4, node);
    }

    [Fact]
    public void Remove_ValueExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.True(node.Remove(2));
        Assert.DoesNotContain(2, node);
    }

    [Fact]
    public void Remove_ValueDoesNotExists_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.False(node.Remove(4));
    }

    [Fact]
    public void CopyTo_CopyValues_Success()
    {
        Node<int> list = new Node<int>(0); //this is necessary 
        list.Append(1); 
        list.Append(2);  
        list.Append(3);  

        int[] array = new int[3];
        list.CopyTo(array, 0);

        Assert.Equal(new int[] { 1, 2, 3 }, array); 
    }

    [Fact]
    public void GetEnumerator_ReturnsValues_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        int[] array = new int[3];
        int i = 0;
        foreach (var item in node)
        {
            array[i++] = item;
        }
        Assert.Equal(new int[] { 1, 2, 3 }, array);
    }

    [Fact]
    public void GetEnumerator_ReturnsValuesInCorrectOrder_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        int[] array = new int[3];
        int i = 0;
        foreach (var item in node)
        {
            array[i++] = item;
        }
        Assert.Equal(new int[] { 1, 2, 3 }, array);
    }

}
