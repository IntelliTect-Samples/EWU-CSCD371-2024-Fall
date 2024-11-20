using System.Collections;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public void Append(T val)
    {
        if (Exists(val))
        {
            throw new ArgumentException("Value already exists in the list");
        }

        Node<T> newNode = new(val);
        Node<T> lastNode = Next;
        newNode.Next = lastNode;
        Next = newNode;
    }

    public override string? ToString()
    {
        return Value?.ToString();
    }

    public bool Exists(T? expectedValue)
    {
        Node<T> current = this;

        do
        {
            if ((current.Value is null && expectedValue is null) || current.Value?.Equals(expectedValue) == true)
            {
                return true;
            }
            current = current.Next;
        } while (current != this);

        return false;
    }

    // By ensuring that each node points only to itself, we effectively break the circular references.
    // This allows the garbage collector to reclaim the memory for all nodes except the current one.
    // If we just set the first node's Next to itself, this would work as long as no other nodes are stored in a variable.
    // If one of the Nodes had been stored in a variable, some of the list would still exist.
    public void Clear()
    {
        if (this.Next == null)
        {
            return;
        }

        Node<T> traversal = this;
        Node<T> old = this;

        do
        {
            traversal = traversal.Next;
            old.Next = old;
            old = traversal;
        } while (traversal != this);
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;

        do
        {
            if (current.Value is not null)
            {
                yield return current.Value;
            }
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        throw new NotImplementedException();
    }
}