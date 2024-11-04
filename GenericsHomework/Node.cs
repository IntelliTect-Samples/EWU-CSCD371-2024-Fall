namespace GenericsHomework;
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

    public void SetNext(Node<T> nextNode)
    {
        Next = nextNode ?? throw new ArgumentNullException(nameof(nextNode));
    }

}
