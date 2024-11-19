namespace Assignment.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_SetsDataAndNextReferencesItself()
    {
        // Arrange
        string data = "Rhaenyra Targaryen";

        // Act
        Node<string> node = new(data);

        // Assert
        Assert.Equal(data, node.Data);
        Assert.Same(node, node.Next);
    }

    [Fact]
    public void Add_AddsNewNodeToCircularList()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        Node<string> newNode = new("Daemon Targaryen");

        // Act
        node.Add(newNode);

        // Assert
        Assert.Same(newNode, node.Next);
        Assert.Same(node, node.Next.Next); // Circular structure
    }

    [Fact]
    public void Exists_ReturnsTrue_IfNodeExists()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        node.Append("Daemon Targaryen");
        node.Append("Alicent Hightower");

        // Act
        bool exists = node.Exists("Daemon Targaryen");

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public void Exists_ReturnsFalse_IfNodeDoesNotExist()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        node.Append("Daemon Targaryen");

        // Act
        bool exists = node.Exists("Otto Hightower");

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void Remove_RemovesNodeFromCircularList()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        node.Append("Daemon Targaryen");
        node.Append("Alicent Hightower");
        node.Append("Viserys Targaryen");

        // Act
        bool removed = node.Remove("Daemon Targaryen");

        // Assert
        Assert.True(removed);
        Assert.False(node.Exists("Daemon Targaryen"));
    }

    [Fact]
    public void GetEnumerator_EnumeratesThroughCircularList()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        node.Append("Daemon Targaryen");
        node.Append("Alicent Hightower");
        node.Append("Viserys Targaryen");

        // Act
        List<string> values = node.ToList();

        // Assert
        List<string> expectedValues = new()
        {
            "Rhaenyra Targaryen",
            "Daemon Targaryen",
            "Alicent Hightower",
            "Viserys Targaryen"
        };

        Assert.True(values.Zip(expectedValues, (actual, expected) => actual == expected).All(result => result));
    }

    [Fact]
    public void Append_ThrowsArgumentException_WhenDataAlreadyExists()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        node.Append("Daemon Targaryen");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append("Daemon Targaryen"));
    }

    [Fact]
    public void Collection_CountsNodesCorrectly()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        List<string> names = new()
        {
            "Daemon Targaryen", "Alicent Hightower", "Viserys Targaryen",
            "Helaena Targaryen", "Aegon II Targaryen", "Lucerys Velaryon"
        };

        foreach (string name in names)
        {
            node.Append(name);
        }

        // Act
        int count = node.Count();

        // Assert
        Assert.Equal(7, count);
    }

    [Fact]
    public void Collection_ContainsSpecificNode()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        List<string> names = new()
        {
            "Daemon Targaryen", "Alicent Hightower", "Viserys Targaryen"
        };

        foreach (string name in names)
        {
            node.Append(name);
        }

        // Act
        bool containsViserys = node.Contains("Viserys Targaryen");
        bool containsDaemon = node.Contains("Daemon Targaryen");
        bool containsUnknown = node.Contains("Unknown");

        // Assert
        Assert.True(containsViserys);
        Assert.True(containsDaemon);
        Assert.False(containsUnknown);
    }

    [Fact]
    public void Append_MaintainsCircularStructure_ForLargeNumberOfNodes()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        List<string> names = new()
        {
            "Daemon Targaryen", "Alicent Hightower", "Viserys Targaryen",
            "Helaena Targaryen", "Aegon II Targaryen", "Lucerys Velaryon"
        };

        // Act
        foreach (string name in names)
        {
            node.Append(name);
        }

        // Assert
        List<string> actualSequence = node.ToList();
        List<string> expectedSequence = new()
        {
            "Rhaenyra Targaryen", "Daemon Targaryen", "Alicent Hightower",
            "Viserys Targaryen", "Helaena Targaryen", "Aegon II Targaryen", "Lucerys Velaryon"
        };

        Assert.True(actualSequence.SequenceEqual(expectedSequence));
    }

    [Fact]
    public void ChildItems_ReturnsSortedNodes()
    {
        // Arrange
        Node<string> node = new("Rhaenyra Targaryen");
        List<string> names = new()
        {
            "Daemon Targaryen", "Alicent Hightower", "Viserys Targaryen",
            "Helaena Targaryen", "Aegon II Targaryen", "Lucerys Velaryon"
        };

        foreach (string name in names)
        {
            node.Append(name);
        }

        // Act
        List<string> allNodes = new() { node.Data };
        allNodes.AddRange(node.ChildItems(10));
        List<string> sortedNodes = allNodes.OrderBy(name => name).ToList();

        // Assert
        List<string> expectedSortedItems = new()
        {
            "Aegon II Targaryen", "Alicent Hightower", "Daemon Targaryen",
            "Helaena Targaryen", "Lucerys Velaryon", "Rhaenyra Targaryen",
            "Viserys Targaryen"
        };

        Assert.True(sortedNodes.SequenceEqual(expectedSortedItems));
    }

}
