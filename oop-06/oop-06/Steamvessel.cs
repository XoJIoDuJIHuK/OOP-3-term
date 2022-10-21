class Steamvessel : Ship
{
    public new int _Draught = 450;
    public Steamvessel(int draught, string name, int captainAge, int passengersCapacity)
    {
        if (captainAge < 0) throw new InvalidDataException("возраст капитана", "корвет");
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