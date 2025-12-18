using System.Collections;

namespace TDD;

public class CustomList<T>: IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    public int Count { get; private set; }

    public int Capacity
    {
        get { return _capacity; }
        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException("Capacity must be grater or equal Count");
            }
            _capacity = value;
        }
    }
    
    private int _capacity;

    private T[] _items;
    
    public CustomList():this(DefaultCapacity){}


    public CustomList(int size)
    {
        _capacity = size;
        Count = 0;
        _items = new T[_capacity];
    }

    public CustomList(IEnumerable<int> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        _capacity = collection.Count();
        Count = collection.Count();
        _items = new T[_capacity];
        Array.Copy(collection.ToArray(), 0, _items, 0, _capacity);
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
        return GetEnumerator();
    }

    public T this[int index]
    {
        get {return _items[index];}
        set {_items[index] = value;}
    }

    public void Add(T item)
    {
        if (Count == _capacity)
        {
            _capacity *= 2;
            var temp = new T[_capacity];
            Array.Copy(_items ,temp, _items.Length);
            _items = temp;
        }
        
        _items[Count] = item;
        Count++;
    }
}