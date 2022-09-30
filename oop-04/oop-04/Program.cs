interface ISwim
{
    void Honk(int count);
    void CountIncome(double distance);
}

abstract class Vehicle : ISwim
{
    public abstract void Honk(int count);
    public abstract void CountIncome(double distance);
}

class Ship : Vehicle
{
    public override void Honk(int count) { }
    public override void CountIncome(double distance) { }
    public int _Velocity { get; set; }
    public int _PassengersCapacity { get; set; }
    public override string ToString()
    {
        string str = "Ship Velocity = " + _Velocity.ToString() + ", PassengersCapacity = " + _PassengersCapacity.ToString();
        return str;
    }
}

class Steamvessel : Ship
{
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Steamvessel hasn't honked");
        else if (count == 1) Console.WriteLine("Steamvessel has honked 1 time");
        else if (count > 1) Console.WriteLine($"Steamvessel has honked {count} times");
        else return;
    }
    public override void CountIncome(double distance)
    {
        double Income = distance * _Velocity * _PassengersCapacity;
        Console.WriteLine($"Estimated income is {Income}");
    }
    public Steamvessel()
    {
        _Velocity = 40;
        _PassengersCapacity = 150;
    }
    public override string ToString()
    {
        string str = "Steamvessel Velocity = " + _Velocity.ToString() + ", PassengersCapacity = " +
            _PassengersCapacity.ToString();
        return str;
    }
}
class Sailship : Ship
{
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Sailship hasn't bonked");
        else if (count == 1) Console.WriteLine("Sailship has bonked 1 time");
        else if (count > 1) Console.WriteLine($"Sailship has bonked {count} times");
        else return;
    }
    public override void CountIncome(double distance)
    {
        double Income = 0.7 * distance * _Velocity * _PassengersCapacity;
        Console.WriteLine($"Estimated income is {Income}");
    }
    public Sailship()
    {
        _Velocity = 20;
        _PassengersCapacity = 100;
    }
    public override string ToString()
    {
        string str = "Sailship Velocity = " + _Velocity.ToString() + ", PassengersCapacity = " +
            _PassengersCapacity.ToString();
        return str;
    }
}
sealed class Corvette : Ship
{
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Corvette hasn't bonked");
        else if (count == 1) Console.WriteLine("Corvette has bonked 1 time");
        else if (count > 1) Console.WriteLine($"Corvette has bonked {count} times");
        else return;
    }
    public override void CountIncome(double distance)
    {
        double Income = 0.5 * distance * _Velocity * _PassengersCapacity;
        Console.WriteLine($"Estimated income is {Income}");
    }
    public Corvette()
    {
        _Velocity = 30;
        _PassengersCapacity = 50;
    }
    public override string ToString()
    {
        string str = "Corvette Velocity = " + _Velocity.ToString() + ", PassengersCapacity = " +
            _PassengersCapacity.ToString();
        return str;
    }
}
//class Boat : Vehicle
//{
//    public override void Honk(int count)
//    {
//        Console.WriteLine("Boat doesn't honk");
//    }
//    public override void CountIncome(double distance)
//    {
//        Console.WriteLine($"Estimated income is 0");
//    }
//    public int _Velocity { get; set; }
//    public int _PassengersCapacity { get; set; }
//    public Boat()
//    {
//        _Velocity = 5;
//        _PassengersCapacity = 8;
//    }
//    public override string ToString()
//    {
//        string str = "Boat Velocity = " + _Velocity.ToString() + ", PassengersCapacity = " + _PassengersCapacity.ToString();
//        return str;
//    }
//    public override int GetHashCode()
//    {
//        return (_Velocity * 10 + _PassengersCapacity) % 13;
//    }
//    public override bool Equals(object? obj)
//    {
//        if (obj == null) return false;
//        if (_PassengersCapacity == ((Boat)obj)._PassengersCapacity && _Velocity == ((Boat)obj)._Velocity) return true;
//        else return false;
//    }
//}
//class Captain : ISwim
//{
//    public virtual void Smoke()
//    {
//        Console.WriteLine("Captain smokes");
//    }
//    public void Honk(int count)
//    {
//        Console.WriteLine("Captain screams 'Help!'");
//    }
//    public void CountIncome(double distance)
//    {
//        Console.WriteLine("Captain doesn't make income");
//    }
//    public int _Velocity { get; set; }
//    public Captain()
//    {
//        _Velocity = 1;
//    }
//    public override string ToString()
//    {
//        string str = "Captain Velocity = " + _Velocity.ToString();
//        return str;
//    }
//}
//class Printer
//{
//    public string IAmPrinting(ISwim someobj)
//    {
//        if (someobj == null) return "";
//        else return someobj.ToString();
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        Ship obj1 = new Ship();
//        Corvette obj2 = obj1 as Corvette; // null
//        Corvette obj3 = new Corvette();
//        Ship obj4 = obj3 as Ship; //Ship {Corvette}

//        Boat boat = new();
//        Steamvessel stem = new();
//        Sailship sail = new();
//        Corvette corv = new();
//        bool cond = corv is ISwim;
//        cond = corv is Vehicle;
//        cond = corv is Ship;
//        Printer printer = new Printer();
//        Vehicle[] ships = new Vehicle[4];
//        ships[0] = boat;
//        ships[1] = stem;
//        ships[2] = sail;
//        ships[3] = corv;
//        for (int i = 0; i < ships.Length; i++)
//        {
//            Console.WriteLine($"{printer.IAmPrinting(ships[i])}");
//        }
//    }
//}