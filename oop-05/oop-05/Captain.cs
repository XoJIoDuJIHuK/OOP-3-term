class Captain : ISwim
{
    public virtual void Smoke()
    {
        Console.WriteLine("Captain smokes");
    }
    public void Honk(int count)
    {
        Console.WriteLine("Captain screams 'Help!'");
    }
    public void CountIncome(double distance)
    {
        Console.WriteLine("Captain doesn't make income");
    }
    public int _Velocity { get; set; }
    public Captain()
    {
        _Velocity = 1;
    }
    public override string ToString()
    {
        string str = "Captain Velocity = " + _Velocity.ToString();
        return str;
    }
}