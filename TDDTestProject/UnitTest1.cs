using TDD;

namespace TDDTestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CountMustBeZeroAfterListCreation()
    {
        CustomList<int> list = new CustomList<int>();
        Assert.That(list.Count, Is.EqualTo(0));
    }

    [Test]
    public void CapacityCanSetByListCreation()
    {
        int expectedCapacity = 8;
        CustomList<int> list = new CustomList<int>(expectedCapacity);
        Assert.That(list.Capacity, Is.EqualTo(expectedCapacity));
    }

    [Test]
    public void ExceptionIfConstructorTakeNullCollection()
    {
        IEnumerable<int> collection = null;
        Assert.Throws<ArgumentNullException>(() => new CustomList<int>(collection));
    }

    [Test]
    public void CapacityIsEqualCollectionLenghtAfterListCreation()
    {
        IEnumerable<int> collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        Assert.IsTrue(list.Capacity == collection.Count());
    }

    [Test]
    public void CollectionItemsExistAfterListCreation()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        int i = 0;
        foreach (var item in list)
        {
            Assert.IsTrue(item == collection[i]);
            i++;
        }

        Assert.IsTrue(collection.Length == i);
    }

    [Test]
    public void CanGetListItemByIndex()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(list[i], collection[i]);
        }
    }

    [Test]
    public void CanSetListItemByIndex()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        int value = 99;
        list[list.Count - 1] = value;
        Assert.IsTrue(list[list.Count - 1] == value);
    }

    [Test]
    public void ArgumentOutOfRangeExceptionIfIndexLessThanZero()
    {
        var list = new CustomList<int>();
        Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 1);
    }

    [Test]
    public void ArgumentOutOfRangeExceptionIfIndexGreaterOrEqualCount()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        Assert.Throws<IndexOutOfRangeException>(() => list[list.Count] = 9);
    }

    [Test]
    public void CountIncreasedAfterItemAdded()
    {
        int size = 10;
        var list = new CustomList<int>();
        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        Assert.AreEqual(size, list.Count);
    }

    [Test]
    public void ItemExistAfterItemAdded()
    {
        int size = 10;
        var list = new CustomList<int>();
        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        for (int i = 0; i < size; i++)
        {
            Assert.IsTrue(list[i] == i);
        }
    }

    [Test]
    public void CapacityMustBeGraterThatCount()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Capacity = list.Count - 1);
    }
}