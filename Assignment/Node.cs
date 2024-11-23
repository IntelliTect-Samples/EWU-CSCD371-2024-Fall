using System.Collections;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T? Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public override string? ToString() => Value?.ToString();

    public void Append(T value)
    {
        if (value == null || Exists(value))
            throw new ArgumentException("Value already exists or is null", nameof(value));

        Node<T> node = new(value);
        Node<T> current = this;

        while (current.Next != this)
        {
            current = current.Next;
        }

        current.Next = node;
        node.Next = this;
    }

    public void Clear()
    {
        Node<T> current = Next;

        while (current != this)
        {
            Node<T> temp = current;
            current = current.Next;
            temp.Next = temp;
        }

        Next = this;
    }

    public bool Exists(T value)
    {
        Node<T> current = this;

        do
        {
            if (current.Value != null && current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        }
        while (current != this);

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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int num)
    {
        if (num <= 0) yield break;

        int counter = 0;
        Node<T> start = this;
        Node<T> current = start;

        do
        {
            yield return current.Value!;
            current = current.Next;
            counter++;

        } while (counter < num && current != start);
    }
}
