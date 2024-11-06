namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Constructor_InitNode_Success()
        {
            Node<int> node = new(1);
            Node<int?> node2 = new(null);
            Assert.AreEqual(1, node.Value);
            Assert.AreEqual(null, node2.Value);
        }

        [TestMethod]
        public void Append_AddNode_Success() 
        {
            Node<int> node = new(1);
            node.Append(2);
            Assert.AreEqual(2, node.Next.Value);
        }

        [TestMethod]
        public void Append_AddDuplicateNode_ThrowsInvalidOperationException()
        {
            Node<int> node = new(1);
            node.Append(2);
            Assert.ThrowsException<InvalidOperationException>(() => node.Append(2));
        }

        [TestMethod]
        public void Exists_ChecksIfValueInList_Success()
        {
            Node<int?> node = new(1);
            node.Append(2);
            node.Append(null);
            Assert.IsTrue(node.Exists(2));
            Assert.IsTrue(node.Exists(null));
            Assert.IsFalse(node.Exists(3));
        }

        [TestMethod]
        public void Clear_ClearsList_Success()
        {
            Node<int> node = new(1);
            node.Append(2);
            node.Clear();
            Assert.AreEqual(node, node.Next);
        }

        [TestMethod]
        public void ToString_ReturnsValueAsString_Success()
        {
            Node<int> node = new(1);
            Node<int?> node2 = new(null);
            Assert.AreEqual("1", node.ToString());
            Assert.AreEqual(null, node2.ToString());
        }
    }
}