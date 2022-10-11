using System;
    
interface IPringtingDevice
{
    public string format { get; set; }
    public string color { get; set; }
    public int speed { get; set; }
}
public interface IComparable
{
    int CompareTo(object? o);
}