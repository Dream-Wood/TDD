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
            Assert.IsTrue(list[i] == collection[i]);
        }
    }
    
    [Test]
    public void CanSetListItemByIndex()
    {
        int[] collection = [1, 2, 3, 5];
        var list = new CustomList<int>(collection);
        int value = 99;
        int expectedIndex = 1;
        list[expectedIndex - 1] = value;
        Assert.IsTrue(list[expectedIndex - 1] == value);
    }
}