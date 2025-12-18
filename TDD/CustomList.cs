using System.Collections;

namespace TDD;

public class CustomList<T>: IEnumerable<T>
{
    public int Count { get; private set; }
    public int Capacity { get; set; }
    private const int DefaultCapacity = 4;
    public CustomList():this(DefaultCapacity){}

    private T[] _items;

    public CustomList(int size)
    {
        Capacity = size;
        Count = 0;
    }

    public CustomList(IEnumerable<int> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        Capacity = collection.Count();
        _items = new T[Capacity];
        Array.Copy(collection.ToArray(), 0, _items, 0, Capacity);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }
}