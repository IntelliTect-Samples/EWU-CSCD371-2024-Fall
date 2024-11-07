﻿namespace GenericsHomework;
public class Node<T>
{
    public T? Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T? value)
    {
        Value = value;

        // Ensures that the next node is not null, points to itself.
        Next = this;
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public void Append(T? value)
    {
        if (Exists(value))
            throw new InvalidOperationException($"Duplicate value exists, not allowed: {value}");
        

        Node<T> newNode = new(value)
        {
            Next = this.Next // New Node points back to original.
        };

        this.Next = newNode; // current node now points to new node, using this. for clarity.
    }

    public void Clear()
    {
        // Check to see if Next is equal to itself, if so, it is the only node in the list.
        if (this.Next == this)
            return;

        Node<T> current = this.Next;

        // Traverse the list until we reach the final node.
        while (current != this)
        {
            Node<T> nextNode = current.Next;
            current.Next = current;
            current = nextNode;
        }

        // Set the original node to point to itself. The list is now empty.
        this.Next = this;

        // Garbage collection isn't a concern after setting this.Next to this because the other nodes are no longer reachable, there is no other variables that host potential to have other nodes.
        // However, to address the concern of any other potential pointers, we can set each node Next to itself. Garbage collection will take care of the rest.
    }

    public bool Exists(T? value)
    {
        Node<T> current = this;

        // Traverse the list until we circle back to the starting node.
        do
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }

}