namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_WithValidData_InitializesWithSelfReferencingNext()
    {
        // Arrange
        int data = 1;

        // Act
        Node<int> node = new(data);

        // Assert
        Assert.Equal(data, node.Data);
        Assert.Equal(node, node.Next); // Self-referencing
    }

    [Fact]
    public void Append_WhenAddingNodesWithNullOrEmptyStrings_HandlesEmptyStringCorrectly()
    {
        // Arrange
        Node<string> head = new("Head");

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
        Node<int> head = new Node<int>(0);
        int largeCount = 1000;

        for (int i = 1; i <= largeCount; i++)
        {
            head.Append(i);
        }

        // Act
        Node<int> current = head;
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
        Node<int> head = new Node<int>(1);
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
        Node<object> head = new Node<object>("Head");
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
        Node<object> head = new(1);
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
        Node<int> head = new (1);

        // Act
        bool exists = head.Exists(0);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void Append_WhenAddingAfterClear_AllowsNewDataSuccessfully()
    {
        // Arrange
        Node<int> head = new (1);
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
        Node<object> head = new("Start");
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
        Node<string> head = new("Head");
        int largeCount = 500;

        for (int i = 1; i <= largeCount; i++)
        {
            head.Append("Node" + i);
        }

        // Act
        Node<string> current = head;
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
        Node<int> head = new(1);
        head.Clear(); // Clear once to start

        // Act & Assert
        var exception = Record.Exception(() => head.Clear());
        Assert.Null(exception); // Ensure no exception is thrown on re-clearing
    }
}



