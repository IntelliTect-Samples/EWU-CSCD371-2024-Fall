namespace GenericsHomework;
public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"Value: {Value}";
    }

}
