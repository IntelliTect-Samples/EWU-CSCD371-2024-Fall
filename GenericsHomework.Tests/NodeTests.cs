namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_WithValidData_InitializesWithSelfReferencingNext()
    {
        // Arrange
        int data = 1;

        // Act
        NodeCollection<int> node = new(data);

        // Assert
        Assert.Equal(data, node.Data);
        Assert.Equal(node, node.Next); // Self-referencing
    }

    [Fact]
    public void Append_WhenAddingNodesWithNullOrEmptyStrings_HandlesEmptyStringCorrectly()
    {
        // Arrange
        NodeCollection<string> head = new("Head");

        // Act
        head.Append("First");
        head.Append(string.Empty);
        head.Append("Second");

        // Assert
        Assert.True(head.Exists(string.Empty)); // Ensure empty string node was added
    }

    [Fact]
    public void Append_WhenAddingNodesToLargeList_MaintainsCorrectCircularStructure()
    {
        // Arrange
        NodeCollection<int> head = new(0);
        int largeCount = 1000;

        for (int i = 1; i <= largeCount; i++)
        {
            head.Append(i);
        }

        // Act
        NodeCollection<int> current = head;
        int count = 1;

        while (current.Next != head)
        {
            current = current.Next;
            count++;
        }

        // Assert
        Assert.Equal(largeCount + 1, count);
        Assert.Equal(head, current.Next); // Circular reference to head
    }

    [Fact]
    public void Append_WhenListContainsDuplicateValues_ThrowsException()
    {
        // Arrange
        NodeCollection<int> head = new(1);
        head.Append(2);
        head.Append(3);

        // Act & Assert
        ArgumentException firstDuplicateException = Assert.Throws<ArgumentException>(() => head.Append(1));
        Assert.Equal("Data already exists in the list", firstDuplicateException.Message);
    }

    [Fact]
    public void Clear_WithMultipleDataTypes_RemovesAllNodesExceptHead()
    {
        // Arrange
        NodeCollection<object> head = new("Head");
        head.Append(1);
        head.Append(2.5);
        head.Append("Tail");

        // Act
        head.Clear();

        // Assert
        Assert.Equal(head, head.Next); // Head is self-referencing
        Assert.False(head.Exists(1));
        Assert.False(head.Exists(2.5));
        Assert.False(head.Exists("Tail"));
    }

    [Fact]
    public void ToString_WithVariousDataTypes_ReturnsCorrectStringRepresentation()
    {
        // Arrange
        NodeCollection<object> head = new(1);
        head.Append("Two");
        head.Append(3.5);

        // Act
        string result = head.ToString();

        // Assert
        Assert.Equal("1 -> Two -> 3.5 -> ", result);
    }

    [Fact]
    public void Exists_WhenListIsEmpty_ReturnsFalse()
    {
        // Arrange
        NodeCollection<int> head = new(1);

        // Act
        bool exists = head.Exists(0);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void Append_WhenAddingAfterClear_AllowsNewDataSuccessfully()
    {
        // Arrange
        NodeCollection<int> head = new(1);
        head.Append(2);
        head.Append(3);

        // Clear the list
        head.Clear();

        // Act
        head.Append(4);
        head.Append(5);

        // Assert
        Assert.Equal(4, head.Next.Data);
        Assert.Equal(5, head.Next.Next.Data);
        Assert.Equal(head, head.Next.Next.Next); // Circular reference to head
    }

    [Fact]
    public void Exists_AfterAppendingMultipleDataTypes_ReturnsCorrectExistence()
    {
        // Arrange
        NodeCollection<object> head = new("Start");
        head.Append(123);
        head.Append(45.67);
        head.Append("End");

        // Act & Assert
        Assert.True(head.Exists(123));
        Assert.True(head.Exists(45.67));
        Assert.True(head.Exists("End"));
        Assert.False(head.Exists("Nonexistent"));
    }

    [Fact]
    public void Append_LargeNumberOfStringNodes_MaintainsCircularReferences()
    {
        // Arrange
        NodeCollection<string> head = new("Head");
        int largeCount = 500;

        for (int i = 1; i <= largeCount; i++)
        {
            head.Append("Node" + i);
        }

        // Act
        NodeCollection<string> current = head;
        int count = 1;

        while (current.Next != head)
        {
            current = current.Next;
            count++;
        }

        // Assert
        Assert.Equal(largeCount + 1, count);
        Assert.Equal(head, current.Next); // Circular reference to head
    }

    [Fact]
    public void Clear_WhenClearingAlreadyClearedList_DoesNotThrowException()
    {
        // Arrange
        NodeCollection<int> head = new(1);
        head.Clear(); // Clear once to start

        // Act & Assert
        var exception = Record.Exception(() => head.Clear());
        Assert.Null(exception); // Ensure no exception is thrown on re-clearing
    }

    [Fact]
    public void Clear_WithMultipleNodes_RemovedNodesPointToThemselves()
    {
        // Arrange
        var node1 = new NodeCollection<int>(1);
        node1.Append(2);
        node1.Append(3);

        // Act
        node1.Clear();

        // Assert
        Assert.Same(node1, node1.Next); // The Next property of the head node should point to itself

        NodeCollection<int> current = node1.Next;
        do
        {
            Assert.Same(current, current.Next); // Each node points to itself
            current = current.Next;
        } while (current != node1);  // Loop through the circular list
    }

    [Fact]
    public void Clear_OnEmptyList_DoesNotThrowAndHeadRemainsSelfReferencing()
    {
        // Arrange
        NodeCollection<object> head = new("Head");

        // Act & Assert
        var exception = Record.Exception(() => head.Clear());
        Assert.Null(exception); // Ensures Clear does not throw an exception
        Assert.Same(head, head.Next); // The head node should still point to itself
    }

    [Fact]
    public void Clear_OnLongList_HeadSelfReferencingAndAllNodesRemoved()
    {
        // Arrange
        NodeCollection<int> head = new(0);
        for (int i = 1; i <= 100; i++)
        {
            head.Append(i);
        }

        // Act
        head.Clear();

        // Assert
        Assert.Same(head, head.Next); // Head should be self-referencing
        for (int i = 1; i <= 100; i++)
        {
            Assert.False(head.Exists(i)); // Each element should be removed
        }
    }
}




