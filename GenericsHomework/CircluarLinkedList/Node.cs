namespace CircluarLinkedList;

public class Node<T>
{
    public T Value { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}