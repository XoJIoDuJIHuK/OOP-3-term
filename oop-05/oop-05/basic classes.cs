interface ISwim
{
    void Honk(int count);
    void CountIncome(double distance);
}

abstract class Vehicle : ISwim
{
    public int _Draught;
    public string _Name = "";
    public int _CaptainAge = 0;
    public int _PassengersCapacity = 0;
    public abstract void Honk(int count);
    public abstract void CountIncome(double distance);
}

class Ship : Vehicle
{
    public override void Honk(int count) { }
    public override void CountIncome(double distance) { }
}