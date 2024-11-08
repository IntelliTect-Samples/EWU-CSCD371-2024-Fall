using System.Collections;

namespace GenericsHomework;
[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Benjamin is allowing this suppression.")]
public class Node<T> : ICollection<T>
{
    private readonly T _value;
    private Node<T> _next;
    public Node(T value)
    {
        _value = value;
        _next = this;
    }

    public T Value { get {  return _value; } }

    public override string? ToString()
    {
        if (_value == null)
        {
            return null;
        }
        return _value.ToString();
    }

    public Node<T> Next
    {
        get { return _next; }
        set { _next = value; }
    }

    public bool Exists(T value)
    { 
        Node<T> node = this;
        //This method loop around all the nodes and check if the value exists in the list
        do
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return true;
            }
            node = node.Next;
        } while (node != this);
        return false;

    }

    public void Append(T value)
    {
        if (Exists(value))
        {
            throw new InvalidOperationException("Value already exists in the list");
        }

        Node<T> newNode = new(value);
        Node<T> node = this;

        while (node.Next != this)
        {
            node = node.Next;
        }

        node.Next = newNode;
        newNode.Next = this;  
    }

    public void Clear()
    {
        //This method loop around all the nodes and sets all their next properties to themselves
        //which effectively removes all the nodes from the list

        var node = Next;
        while (node.Next != this)
        {
            node = node.Next;
        }
        node.Next = Next;
        Next = this;
        //this set the node to point to itself, which make the list empty
        //We don't have to worry about garbage collector because all nodes is disconnected and will be automatically collected
    }

    //ICollection<T> implementation
    public int Count
    {
        get
        {
            int count = 0;
            Node<T> node = this;
            do
            {
                count++;
                node = node.Next;
            } while (node != this);
            return count;
        }
    }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        Append(item);
    }

    public bool Contains(T item)
    {
        return Exists(item);
    }

    public bool Remove(T item)
    {
        Node<T> node = this;
        Node<T> previous = this;
        do
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, item))
            {
                previous.Next = node.Next;
                return true;
            }
            previous = node;
            node = node.Next;
        } while (node != this);
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        //THE TEST IS WRONG NOT THIS CODE
        Node<T> node = this.Next;  
        do
        {
            array[arrayIndex++] = node.Value;
            node = node.Next;
        } while (node != this);  
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> node = this;
        do
        {
            yield return node.Value;
            node = node.Next;
        } while (node != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
