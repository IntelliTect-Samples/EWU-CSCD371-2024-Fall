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

    }

    public Node<T> Append(T value)
    {
        Node<T> newNode = new(value)
        {
            Next = Next
        };
        Next = newNode;
        return newNode;
    }

}
