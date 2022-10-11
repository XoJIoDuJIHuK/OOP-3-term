class Steamvessel : Ship
{
    public new int _Draught = 450;
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Steamvessel hasn't honked");
        else if (count == 1) Console.WriteLine("Steamvessel has honked 1 time");
        else if (count > 1) Console.WriteLine($"Steamvessel has honked {count} times");
        else return;
    }
    public Steamvessel(int draught, string name, int captainAge, int passengersCapacity)
    {
        _PassengersCapacity = passengersCapacity;
        _Draught = draught;
        _Name = name;
        _CaptainAge = captainAge;
    }
    public override string ToString()
    {
        string str = "Type: Steamvessel, name: " + _Name + ", passengers capacity: "
            + _PassengersCapacity.ToString() + ", draught: " + _Draught.ToString() + 
            ", captain age: " + _CaptainAge.ToString();
        return str;
    }
}