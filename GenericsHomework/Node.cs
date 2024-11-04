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

    public void Append(T? value)
    {
        Node<T> newNode = new(value);
        newNode.Next = this.Next; // New Node points back to original.
        this.Next = newNode; // current node now points to new node, using this. for clarity.
    }

}
