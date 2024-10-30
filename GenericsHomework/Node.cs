﻿using System.Text;
using System.Collections;

namespace GenericsHomework;

public class Node<T> : ICollection<T>
{
    public T Data { get; private set; }
    private Node<T> _next;

    public Node<T> Next
    {
        get => _next;
        set => _next = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Node(T data)
    {
        Data = data;
        _next = this;
    }

    public void Append(T data)
    {
        if (Exists(data))
        {
            throw new ArgumentException("Data already exists in the list");
        }

        Node<T> newNode = new(data);
        Node<T> current = this;

        if (current.Next == this)
        {
            current.Next = newNode;
            newNode.Next = this;
        }
        else
        {
            while (current.Next != this)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Next = this;
        }

    }

    public bool Exists(T data)
    {
        Node<T> current = this;

        do
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }

    public override string ToString()
    {
        Node<T> current = this;
        StringBuilder sb = new();

        do
        {
            sb.Append(current.Data);
            sb.Append(" -> ");
            current = current.Next;
        } while (current != this);

        return sb.ToString();
    }

    public void Clear() // Given a circular linked list this will return only the first (head) node having it point at itself allowing all other nodes to be garbage collected
    {
        Node<T> current = Next;
        Node<T> temp;

        while (current != this)
        {
            temp = current.Next;
            current.Next = current;
            current = temp;
        }

        Next = this;
    }

    // ICollection<T> implementation
    public void Add(T item)   // Add and Append are the same
    {
        Append(item);
    }

    public bool Contains(T item) /// Exists and Contains are the same
    {
        return Exists(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Node<T> current = this;
        int index = arrayIndex;

        do
        {
            array[index++] = current.Data;
            current = current.Next;
        } while (current != this);
    }

    public bool Remove(T item) // Remove and clear are the similar
    {
        Node<T>? previous = null;

        Node<T> current = this;
        do
        {
            if (current.Data!.Equals(item))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                }
                else
                {
                    // If the item to remove is the head node
                    if (current.Next == this)
                    {
                        // Only one node in the list
                        return false;
                    }
                    else
                    {
                        // Find the last node
                        Node<T> last = this;
                        while (last.Next != this)
                        {
                            last = last.Next;
                        }
                        last.Next = current.Next;
                        Data = current.Next.Data;
                        Next = current.Next.Next;
                    }
                }
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != this);

        return false;
    }

    public int Count // We can use the Exists method to count the number of nodes
    {
        get
        {
            int count = 0;
            Node<T> current = this;

            do
            {
                count++;
                current = current.Next;
            } while (current != this);

            return count;
        }
    }

    public bool IsReadOnly => false;

    public IEnumerator<T> GetEnumerator() // We can use the Exists method to iterate through the nodes
    {
        Node<T> current = this;
        do
        {
            yield return current.Data;
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
