using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void HasValue()
        {
            Node<int> node = new(1);
            Assert.AreEqual(1, node.Value);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual("1", node1.ToString());
            Node<string> node2 = new("Inigo");
            Assert.AreEqual("Inigo", node2.ToString());
        }


        [TestMethod]
        public void SingleNext()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual(node1, node1.Next);
        }

        [TestMethod]
        public void Insert1()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            Assert.AreEqual(node2, node1.Next);
            Assert.AreEqual(node1, node2.Next);
        }

        [TestMethod]
        public void Insert2()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.AreEqual(node2, node1.Next);
            Assert.AreEqual(node3, node2.Next);
            Assert.AreEqual(node1, node3.Next);
        }


        [TestMethod]
        public void Clear()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.AreEqual(node1, node3.Next);
            node1.Clear();
            Assert.AreEqual(node1, node1.Next);
            Assert.AreEqual(node2, node3.Next);
        }

        [TestMethod]
        public void ClearOnly1()
        {
            Node<int> node1 = new(1);
            Assert.AreEqual(node1, node1.Next);
            node1.Clear();
            Assert.AreEqual(node1, node1.Next);
        }


        [TestMethod]
        public void NullTest()
        {
            Node<string?> node1 = new(null);
            Assert.AreEqual(null, node1.ToString());
        }


        [TestMethod]
        public void Duplicate()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            Assert.IsTrue(node1.Exists(1));
            Assert.IsTrue(node1.Exists(2));
            Assert.IsTrue(node1.Exists(3));
            Assert.IsTrue(node2.Exists(3));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Duplicate")]
        public void DuplicateException()
        {
            Node<int> node1 = new(1);
            var node2 = node1.Append(2);
            var node3 = node2.Append(3);
            var node4 = node3.Append(2);
        }

        [TestMethod]
        public void Node_CanIterate()
        {
            Node<int> node1 = new(0);
            var node2 = node1.Append(1);

            int count = 0;
            foreach (var item in node1)
            {
                count++;
            }

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Node_ThreeNodes_CanIterate()
        {
            Node<int> node1 = new(0);
            node1 = node1.Append(2);
            node1.Append(1);

            int count = 0;
            foreach (var item in node1)
            {
                count++;
            }

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void GetValues_ThreeNodes_ReturnsThreeValues()
        {
            Node<int> node1 = new(2);
            node1.Append(0);
            node1.Append(1);

            Assert.AreEqual(3, node1.GetValues().Count());
            foreach (var item in node1.GetValues().Where(item => item % 2 == 0))
            {
            }
        }


        [TestMethod]
        public void Node_OrderBy()
        {
            Node<int> node1 = new(1);
            node1.Append(1);
            node1.Append(2);

            node1.Select(item => item);

            IOrderedEnumerable<Node<int>> temp =
                node1.OrderBy(item => item)
                .ThenBy(item => item.Value);
        }

        [TestMethod]
        public void Node_Covariance()
        {
            string[] strings = ["", "test", "mark"];

            object[] objects = strings;
            if (objects is not object[]) { Assert.Fail(); }
            Assert.AreEqual(typeof(string[]), objects.GetType());
            Assert.ThrowsException<ArrayTypeMismatchException>(() => objects[1] = 1);


            //List<string> strings = ["", "test", "mark"];
            //List<object> objects = strings;
            //objects[1] = 1;

            //IEnumerable<string> strings = ["", "test", "mark"];
            //IEnumerable<object> objects = strings;
            //objects[1] = 1;

            //ICollection<string> strings2 = ["", "test", "mark"];
            //ICollection<object> objects2 = strings2;

            IReadOnlyList<string> strings1 = ["", "yellow", "palevioletred"];
            IReadOnlyList<object> objects1 = strings1;


            //IReadWriteEnumerable<string>? strings2 = null;
            //IReadWriteEnumerable<object>? objects2 = strings2;

        }

        [TestMethod]
        public void DelegateAssignment()
        {
            Action<object> pink = (object number) => { };
            Action<string> foo = pink;

            Func<string> black = () => { return ""; };
            Func<object> foo1 = black;



        }

        [TestMethod]
        public void GetMembers()
        {
            int counter = 0;
            var resultEnumerable = typeof(string).GetMembers().AsEnumerable()
            //.Select(item =>
            //{
            //    counter++;
            //    return item.Name;
            //});

            /*resultEnumerable = resultEnumerable*/.Where(
                item =>
                {
                    var name = item.Name;
                    return name.StartsWith("T", StringComparison.CurrentCultureIgnoreCase);
                }).Select(item => item.Name);

            IEnumerable<string> result = resultEnumerable.ToList();

            Func<IEnumerable<string>?, int> count =
                 (IEnumerable<string>? items) =>
            {
                items ??= Enumerable.Empty<string>();
                int counter1 = 0;
                foreach (var item in items)
                {
                    counter1++;
                }
                return counter1;
            };
            var resultCount = resultEnumerable.Count();
            Assert.AreEqual(counter, count(result));
            var result2Count = resultEnumerable.Count();
            Assert.AreEqual(counter, result2Count);
        }
    }

    public interface IReadWriteEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}