
namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Constructor_ValidValue_CreatesNode()
    {
        // Arrange & Act
        Node<int> node = new(1);

        // Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(1, node.Value);
        Assert.AreEqual(node, node.Next);
    }

        [TestMethod]
    public void Exists_ValueExists_ReturnsTrue()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        bool exists = node.Exists(2);

        // Assert
        Assert.IsTrue(exists);
    }

    [TestMethod]
    public void Exists_ValueDoesNotExist_ReturnsFalse()
    {
        // Arrange
        Node<int> node = new(1);

        // Act
        bool exists = node.Exists(2);

        // Assert
        Assert.IsFalse(exists);
    }

    [TestMethod]
    public void Clear_list_RemovesNodes()
    {
        // Arrange
        Node<int> node = new(99);
        node.Append(3);
        node.Append(8);

        // Act
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
    }

    [TestMethod]
    public void Append_Value_AddsNodeToList()
    {
        // Arrange
        Node<int> node = new(8);

        // Act
        node.Append(11);
        node.Append(23);

        // Assert
        Assert.IsTrue(node.Exists(11));
        Assert.IsTrue(node.Exists(23));
        Assert.AreEqual(8, node.Value);
        Assert.AreEqual(11, node.Next.Value);
        Assert.AreEqual(23, node.Next.Next.Value);
        Assert.AreEqual(node, node.Next.Next.Next);
    }

    [TestMethod]
    public void ChildItems_ValidNumber_ReturnsCorrectItems()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        List<int> items = node.ChildItems(2).ToList();

        // Assert
        CollectionAssert.AreEqual(new List<int> { 1, 2 }, items);
    }


}