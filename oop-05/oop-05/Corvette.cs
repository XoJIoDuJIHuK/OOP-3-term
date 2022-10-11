sealed class Corvette : Ship
{
    public new int Draught = 150;
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Corvette hasn't bonked");
        else if (count == 1) Console.WriteLine("Corvette has bonked 1 time");
        else if (count > 1) Console.WriteLine($"Corvette has bonked {count} times");
        else return;
    }
    public Corvette(int draught, string name, int captainAge, int passengersCapacity)
    {
        _PassengersCapacity = passengersCapacity;
        _Draught = draught;
        _Name = name;
        _CaptainAge = captainAge;
    }
    public override string ToString()
    {
        string str = "Type: Corvette, name: " + _Name + ", passengers capacity: "
            + _PassengersCapacity.ToString() + ", draught: " + _Draught.ToString() +
            ", captain age: " + _CaptainAge.ToString();
        return str;
    }
}