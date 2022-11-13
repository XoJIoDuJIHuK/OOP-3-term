using System.Collections;

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
//    public void Add(Plant item)
//    {
//        _set.Add(item);
//    }
//    public void Clear()
//    {
//        _set.Clear();
//    }
//    public bool Contains(Plant item)
//    {
//        return _set.Contains(item);
//    }
//    public void CopyTo(Plant[] array, int arrayIndex)
//    {
//        for (int i = arrayIndex; i < array.Length; i++) _set.Add(array[i]);
//    }
//    public IEnumerator<Plant> GetEnumerator()
//    {
//        return new HashSet<Plant>.Enumerator();
//    }
//    public int IndexOf(Plant item)
//    {
//        int i = 0;
//        foreach (var plant in _set)
//        {
//            if (plant.Equals(item)) return i;
//            i++;
//        }
//        return -1;
//    }
//    public void Insert(int index, Plant item)
//    {
//        Add(item);
//    }
//    public bool Remove(Plant item)
//    {
//        return _set.Remove(item);
//    }
//    public void RemoveAt(int index)
//    {
//        int i = 0;
//        foreach (var plant in _set)
//        {
//            if (i == index)
//            {
//                Remove(plant);
//                return;
//            }
//            i++;
//        }
//    }
//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return GetEnumerator();
//    }
//    public void Write()
//    {
//        foreach(var item in _set)
//        {
//            Console.WriteLine(item.ToString());
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        CCollection collection = new CCollection();
//        Plant a = new("green", 1.2);
//        Plant b = new("blue", 2.5);
//        Plant c = new("black", 5.3);
//        collection.Add(a);
//        collection.Add(b);
//        collection.Add(c);
//        collection.Write();
//        Console.WriteLine();
//        collection.Remove(b);
//        collection.Write();
//        Console.WriteLine();
//        Console.WriteLine(collection.IndexOf(a));
//    }
//}