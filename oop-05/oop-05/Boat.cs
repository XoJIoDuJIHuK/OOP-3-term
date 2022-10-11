class Boat : Vehicle
{
    public new int Draught = 3;
    public int a
    {
        get;
    }
    public override void Honk(int count)
    {
        Console.WriteLine("Boat doesn't honk");
    }
    public override void CountIncome(double distance)
    {
        Console.WriteLine($"Estimated income is 0");
    }
    public Boat(int draught, string name, int captainAge, int passengersCapacity)
    {
        _PassengersCapacity = passengersCapacity;
        _Draught = draught;
        _Name = name;
        _CaptainAge = captainAge;
    }
    public override string ToString()
    {
        string str = "Type: Boat, name: " + _Name + ", passengers capacity: "
            + _PassengersCapacity.ToString() + ", draught: " + _Draught.ToString() +
            ", captain age: " + _CaptainAge.ToString();
        return str;
    }
}