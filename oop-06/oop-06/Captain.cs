class Captain : ISwim
{
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