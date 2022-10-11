class Sailship : Ship
{
    public new int _Draught = 200;
    public override void Honk(int count)
    {
        if (count == 0) Console.WriteLine("Sailship hasn't bonked");
        else if (count == 1) Console.WriteLine("Sailship has bonked 1 time");
        else if (count > 1) Console.WriteLine($"Sailship has bonked {count} times");
        else return;
    }
    public Sailship(int draught, string name, int captainAge, int passengersCapacity)
    {
        _PassengersCapacity = passengersCapacity;
        _Draught = draught;
        _Name = name;
        _CaptainAge = captainAge;
    }
    public override string ToString()
    {
        string str = "Type: Sailship, name: " + _Name + ", passengers capacity: "
            + _PassengersCapacity.ToString() + ", draught: " + _Draught.ToString() +
            ", captain age: " + _CaptainAge.ToString();
        return str;
    }
}