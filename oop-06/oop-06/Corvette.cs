sealed class Corvette : Ship
{
    public new int Draught = 150;
    public Corvette(int draught, string name, int captainAge, int passengersCapacity)
    {
        if (passengersCapacity > 300) throw new InvalidDataException("количество пассажиров", "корвет");
        if (captainAge < 0) throw new InvalidDataException("возраст капитана", "корвет");
        if (draught > 20000) throw new InvalidDataException("водоизмещение", "корвет");
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