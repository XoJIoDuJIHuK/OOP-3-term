class Boat : Vehicle
{
    public int Draught = 3;
    public int a
    {
        get;
    }
    public Boat(int draught, string name, int captainAge, int passengersCapacity)
    {
        if (passengersCapacity < 1500) throw new InvalidDataException("количество пассажиров", "лодка");
        if (captainAge < 0) throw new InvalidDataException("возраст капитана", "лодка");
        if (draught < 20000) throw new InvalidDataException("водоизмещение", "лодка");
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