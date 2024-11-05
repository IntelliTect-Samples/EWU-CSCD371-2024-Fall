namespace GenericsHomework;

public class Node<T>
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

    public Node<T> Append(T value)
    {
        if (Exists(value))
        {
            throw new InvalidOperationException("Value already exists in the list");
        }
        Node<T> newNode = new(value)
        {
            Next = Next
        };
        Next = newNode;
        return newNode;
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

}
