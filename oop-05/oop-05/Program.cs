using System.Collections.Generic;

partial class Printer
{
    public string IAmPrinting(ISwim someobj)
    {
        if (someobj == null) return "";
        else return someobj.ToString();
    }
}

struct myStruct
{
    public int _size = 0;
    public string _name = "John";
    myStruct(int size, string name)
    {
        _size = size;
        _name = name;
    }
}

enum ships
{
    Corvette = 1,
    Sailship,
    Boat
}
class Controller
{
    public int AverageDraught(Container? obj)
    {
        if (obj != null) return obj.AverageDraught();
        else 
        { 
            Console.WriteLine("Container is null");
            return -1;
        }
    }
    public int AverageNumberOfPlaces(Container? obj)
    {
        if (obj != null) return obj.AverageNumberOfPlaces();
        else
        {
            Console.WriteLine("Container is null");
            return -1;
        }
    }
    public void AllVehiclesBasedOnCaptains(Container? obj)
    {
        if (obj != null) obj.AllVehiclesBasedOnCaptains();
        else
        {
            Console.WriteLine("Container is null");
        }
    }
}
class Program
{
    static void Main()
    {
        Container container = new Container();
        var ship1 = new Corvette(500, "St. George", 40, 100);
        var ship2 = new Sailship(2000, "Isabelle", 34, 250);
        var ship3 = new Steamvessel(5000, "St. Maria", 20, 400);
        var ship4 = new Boat(46500, "Адмирал Кузнецов", 40, 1980);
        container.Add(ship1);
        container.Add(ship2);
        container.Add(ship3);
        container.Add(ship4);
        container.WriteList();
        Console.WriteLine($"Average draught: {container.AverageDraught()}");
        Console.WriteLine($"Average number of places: {container.AverageNumberOfPlaces()}");
        container.AllVehiclesBasedOnCaptains();
    }
}