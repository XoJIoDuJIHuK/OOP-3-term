using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Plant
{
    public string _color;
    public double _age;
    public Plant(string color, double age)
    {
        _color = color;
        _age = age;
    }
    public override string ToString()
    {
        string ret = _color;
        ret += " ";
        ret += _age.ToString();
        return ret;
    }
}

class CCollection : IList<Plant>
{
    private HashSet<Plant> _set;
    public CCollection()
    {
        _set = new HashSet<Plant>();
    }
    public Plant this[int i]
    {
        get { return new Plant("red", 0); }
        set { }
    }
    public int Count
    {
        get { return _set.Count; }
    }
    public bool IsReadOnly
    {
        get { return false; }
    }
    public void Add(Plant item)
    {
        _set.Add(item);
    }
    public void Clear()
    {
        _set.Clear();
    }
    public bool Contains(Plant item)
    {
        return _set.Contains(item);
    }
    public void CopyTo(Plant[] array, int arrayIndex)
    {
        for (int i = arrayIndex; i < array.Length; i++) _set.Add(array[i]);
    }
    public IEnumerator<Plant> GetEnumerator()
    {
        return new HashSet<Plant>.Enumerator();
    }
    public int IndexOf(Plant item)
    {
        int i = 0;
        foreach (var plant in _set)
        {
            if (plant.Equals(item)) return i;
            i++;
        }
        return -1;
    }
    public void Insert(int index, Plant item)
    {
        Add(item);
    }
    public bool Remove(Plant item)
    {
        return _set.Remove(item);
    }
    public void RemoveAt(int index)
    {
        int i = 0;
        foreach (var plant in _set)
        {
            if (i == index)
            {
                Remove(plant);
                return;
            }
            i++;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Write()
    {
        foreach (var item in _set)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
class Program
{
    public static void CC(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
            {
                Console.WriteLine("something added");
                break;
            }
            case NotifyCollectionChangedAction.Remove:
            {
                Console.WriteLine("something removed");
                break;
            }
            case NotifyCollectionChangedAction.Move:
            {
                Console.WriteLine("something moved");
                break;
            }
            default:
            {
                Console.WriteLine("something wrong, i can feel it");
                break;
            }
        }
    }
    static void Main()
    {
        CCollection collection = new CCollection();
        Plant a = new("green", 1.2);
        Plant b = new("blue", 2.5);
        Plant c = new("black", 5.3);
        collection.Add(a);
        collection.Add(b);
        collection.Add(c);
        collection.Write();
        Console.WriteLine();
        collection.Remove(b);
        collection.Write();
        Console.WriteLine();
        Console.WriteLine(collection.IndexOf(a));

        //Task03
        Console.WriteLine("Task03");
        HashSet<int> hashSetTask3 = new();
        for (int i = 0; i < 10; i++) hashSetTask3.Add(i);//первый способ добавления элементов
        foreach (int i in hashSetTask3) Console.WriteLine(i);
        Console.WriteLine();
        Console.Write("n in task03 = ");
        int n = int.Parse(Console.ReadLine());
        int j = 0;
        foreach(int i in hashSetTask3)
        {
            if (j < n) hashSetTask3.Remove(i);
            j++;
        }
        foreach (int i in hashSetTask3) Console.WriteLine(i);
        Console.WriteLine();
        HashSet<int> negs = new();
        for (int i = 0; i < 10; i++) negs.Add(-(i + 1));
        hashSetTask3.UnionWith(negs);//второй способ добавления элементов
        foreach (int i in hashSetTask3) Console.WriteLine(i);
        Console.WriteLine();
        Queue<int> queue = new();
        foreach(int i in hashSetTask3) queue.Enqueue(i);
        foreach (int i in queue) Console.WriteLine(i);
        Console.WriteLine();
        Console.Write("enter value to find: ");
        n = int.Parse(Console.ReadLine());
        bool valueFound = false;
        foreach(int i in queue)
        {
            if (i == n)
            {
                Console.WriteLine($"value {i} found");
                valueFound = true;
                break;
            }
        }
        if (!valueFound) Console.WriteLine($"value {n} not found");

        //Task04
        var obsev = new ObservableCollection<int>();
        obsev.CollectionChanged += CC;
        obsev.Add(23);
        obsev.Add(675);
        obsev.Insert(0, 78);
    }
}