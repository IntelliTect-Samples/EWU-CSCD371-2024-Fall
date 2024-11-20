﻿using System.Collections;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<Node<T>>
    {
        private readonly T _value;
        private Node<T> _next;
        public Node(T value)
        {
            _value = value;
            _next = this;
        }

        public T Value { get { return _value; } }

        public override string? ToString()
        {
            if (_value == null) return null;
            return _value.ToString();
        }

        public Node<T> Next
        {
            get { return _next; }
            private set
            {
                _next = value;
            }
        }

        public Node<T> Append(T value)
        {
            if (Exists(value)) throw new ArgumentException("This item already exists in the list");
            Node<T> newNode = new(value)
            {
                Next = Next
            };
            Next = newNode;
            return newNode;
        }

        public bool Exists(T value)
        {
            var node = this;
            do
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value)) return true;
                node = node.Next;
            } while (node != this);
            return false;
        }

        public void Clear()
        {
            // Setting Next = this is sufficient, however if any other references to nodes are held outside the list, 
            // this cleans them up so that all nodes' Next property reference themselves.

            // This loops around all the nodes and sets all their Next properties to themselves effectively eliminating the list.
            // This works even if there is only a single node.
            var node = Next;
            while (node.Next != this)
            {
                node = node.Next;
            }
            node.Next = Next;
            Next = this;
            // Note that any disconnected nodes will not be found in the reference tree next time and automatically garbage collected.
            // At least once all local instances of other nodes pass out of scope.
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> start = this;
            Node<T> current = start;
            yield return current;

            while (current.Next != start)
            {
                yield return current.Next;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<T> GetValues()
        {
            foreach (var item in this)
            {
                yield return item.Value;
            }
        }
    }
}

