interface ISwim
{
}

abstract class Vehicle : ISwim
{
    public int _Draught;
    public string _Name = "";
    public int _CaptainAge = 0;
    public int _PassengersCapacity = 0;
}

class Ship : Vehicle
{
    
}