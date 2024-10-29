namespace GenericsHomework.Tests;

public class NodeTests
    {
        [Fact]
        public void Constructor_InitializesNodeWithDataAndSelfReferencingNext()
        {
            // Arrange
            int data = 1;

            // Act
            var node = new Node<int>(data);

            // Assert
            Assert.Equal(data, node.Data);
            Assert.Equal(node, node.Next);
        }

        [Fact]
        public void Append_AddsNewNodeToEndOfCircularList_WhenListHasOneNode()
        {
            // Arrange
            var head = new Node<int>(1);

            // Act
            head.Append(2);

            // Assert
            Assert.Equal(2, head.Next.Data);
            Assert.Equal(head, head.Next.Next); // circular reference back to head
        }

        [Fact]
        public void Append_AddsNewNodeToEndOfCircularList_WhenListHasMultipleNodes()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);

            // Act
            head.Append(3);

            // Assert
            Assert.Equal(2, head.Next.Data);
            Assert.Equal(3, head.Next.Next.Data);
            Assert.Equal(head, head.Next.Next.Next); // circular reference back to head
        }

        [Fact]
        public void Append_ThrowsArgumentException_WhenDataAlreadyExists()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => head.Append(1));
        }

        [Fact]
        public void Exists_ReturnsTrue_WhenDataExistsInList()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);
            head.Append(3);

            // Act
            bool exists = head.Exists(2);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void Exists_ReturnsFalse_WhenDataDoesNotExistInList()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);
            head.Append(3);

            // Act
            bool exists = head.Exists(4);

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public void ToString_ReturnsCorrectRepresentationOfList_WithOneNode()
        {
            // Arrange
            var head = new Node<int>(1);

            // Act
            string result = head.ToString();

            // Assert
            Assert.Equal("1 -> ", result);
        }

        [Fact]
        public void ToString_ReturnsCorrectRepresentationOfList_WithMultipleNodes()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);
            head.Append(3);

            // Act
            string result = head.ToString();

            // Assert
            Assert.Equal("1 -> 2 -> 3 -> ", result);
        }

        [Fact]
        public void Clear_RemovesAllNodesExceptHead()
        {
            // Arrange
            var head = new Node<int>(1);
            head.Append(2);
            head.Append(3);

            // Act
            head.Clear();

            // Assert
            Assert.Equal(head, head.Next);
            Assert.False(head.Exists(2));
            Assert.False(head.Exists(3));
        }

        [Fact]
        public void Clear_OnSingleElementList_DoesNotThrowException()
        {
            // Arrange
            var head = new Node<int>(1);

            // Act
            head.Clear();

            // Assert
            Assert.Equal(head, head.Next); // Circular reference should point to itself
        }

        [Fact]
        public void SetNext_ThrowsArgumentNullException_WhenSettingNullValue()
        {
            // Arrange
            var head = new Node<int>(1);
            Node<int>? nullNode = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => head.Next = nullNode!);
        }


        [Fact]
        public void SetNext_SetsNextNodeCorrectly()
        {
            // Arrange
            var head = new Node<int>(1);
            var newNode = new Node<int>(2);

            // Act
            head.Next = newNode;

            // Assert
            Assert.Equal(newNode, head.Next);
        }

        [Fact]
        public void Exists_ReturnsTrue_WhenSearchingHeadDataInSingleNodeList()
        {
            // Arrange
            var head = new Node<int>(1);

            // Act
            bool exists = head.Exists(1);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void Exists_ReturnsFalse_WhenSearchingNonexistentDataInSingleNodeList()
        {
            // Arrange
            var head = new Node<int>(1);

            // Act
            bool exists = head.Exists(2);

            // Assert
            Assert.False(exists);
        }
    }
