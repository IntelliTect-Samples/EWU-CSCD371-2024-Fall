namespace GenericsHomework;

public class Circle<T> where T : class
{
    private readonly HashSet<T> _items;

    public IReadOnlyCollection<T> Items => _items;

    public Circle()
    {
        _items = new HashSet<T>();
    }

    public void AddItem(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }
      
        _items.Add(item);
    }
}
