namespace GenericsHomework;

public class VennDiagram<T> where T : class
{
    private readonly List<Circle<T>> _circles;

    public VennDiagram(int numberOfCircles)
    {
        if (numberOfCircles <= 0)
        {
            throw new ArgumentException("Circles must be > 0.");
        }

        _circles = new List<Circle<T>>(numberOfCircles);

        for (int i = 0; i < numberOfCircles; i++)
        {
            _circles.Add(new Circle<T>());
        }
    }

    public Circle<T> GetCircle(int index)
    {
        if (index < 0 || index >= _circles.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid circle index.");
        }

        return _circles[index];
    }

    public void AddItem(T item, params int[] circleIndexes)
    {
        foreach (var index in circleIndexes)
        {
            GetCircle(index).AddItem(item);
        }
    }

    public IEnumerable<T> GetAllItems()
    {
        return _circles.SelectMany(circle => circle.Items).Distinct();
    }

    public IEnumerable<T> GetUniqueToCircle(int circleIndex)
    {
        var targetCircle = GetCircle(circleIndex).Items;
        var otherItems = _circles.Where((_, idx) => idx != circleIndex)
                                  .SelectMany(circle => circle.Items)
                                  .ToHashSet();

        return targetCircle.Where(item => !otherItems.Contains(item));
    }
}
