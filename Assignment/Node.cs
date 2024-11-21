using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T? Value { get; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string? ToString() => Value?.ToString();

    // Appends a new node right in front of this node
    public void Append(T value)
    {
        if (Exists(value)) throw new ArgumentException("Value already exists in the list", nameof(value));

        Node<T> newNode = new(value)
        {
            Next = this.Next
        };

        this.Next = newNode;
    }

    public void Clear()
    {
        Node<T> current = this;

        while (current.Next != this)
        {
            Node<T> next = current.Next;
            current.Next = this;
            current = next;
        }
    }

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            bool? b = current.Value?.Equals(value);
            if (b!.Value)
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current.Value!;
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<T> ChildItems(int maximum)
    {
        Node<T> current = this.Next;
        int count = 0;

        while (current != this && count < maximum)
        {
            yield return current.Value!;
            current = current.Next;
            count++;
        }
    }
}

