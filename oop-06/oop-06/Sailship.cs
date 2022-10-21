class Sailship : Ship
{
    public new int _Draught = 200;
    public Sailship(int draught, string name, int captainAge, int passengersCapacity)
    {
        if (captainAge < 0) throw new InvalidDataException("возраст капитана", "парсуник");
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