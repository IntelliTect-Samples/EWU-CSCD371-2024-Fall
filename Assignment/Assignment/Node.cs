using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Data { get; private set; }
    private Node<T> _next;

    public Node<T> Next
    {
        get => _next;
        private set => _next = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Node(T data)
    {
        Data = data;
        _next = this; // Circular structure by default.
    }

    // Add method to link the current node to another node.
    public void Add(Node<T> newNode)
    {
        if (newNode == null)
        {
            throw new ArgumentNullException(nameof(newNode));
        }

        Node<T> current = this;
        while (current.Next != this) // Traverse the circle to find the last node.
        {
            current = current.Next;
        }
        current.Next = newNode;
        newNode.Next = this; // Maintain the circular structure.
    }

    // Method to check if a node with the specified data exists.
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

    // Remove method to remove a node with the specified data.
    public bool Remove(T data)
    {
        if (!Exists(data))
        {
            return false; // If the data doesn't exist, no removal is needed.
        }

        Node<T> current = this;
        Node<T>? previous = null;

        // Traverse the circle to find the node to remove.
        do
        {
            if (current.Data!.Equals(data))
            {
                if (previous != null)
                {
                    previous.Next = current.Next; // Bypass the node to remove.
                }
                else
                {
                    // If removing the current node, adjust the structure.
                    if (current.Next == this)
                    {
                        throw new InvalidOperationException("Cannot remove the only node in the circle.");
                    }

                    // Find the last node to update its Next pointer.
                    Node<T> last = this;
                    while (last.Next != this)
                    {
                        last = last.Next;
                    }

                    Data = current.Next.Data; // Copy data from the next node.
                    Next = current.Next.Next; // Skip the next node.
                    last.Next = this; // Update the last node's Next pointer.
                }
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != this);

        return false; // Should never reach here due to Exists check.
    }

    // Implementation of IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current.Data;
            current = current.Next;
        } while (current != this);
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    // Implementation of ChildItems method
    public IEnumerable<T> ChildItems(int maximum)
    {
        if (maximum <= 0)
        {
            yield break; // Return nothing if maximum is non-positive.
        }

        Node<T> current = Next; // Start with the next node.
        int count = 0;

        while (current != this && count < maximum)
        {
            yield return current.Data;
            current = current.Next;
            count++;
        }
    }
}
