class NullException : Exception
{
    public string _method = "";
    public NullException(string method)
    {
        _method = method;
    }
}
class InvalidDataException : Exception
{
    public string _shipType = "";
    public string _field = "";
    public InvalidDataException(string field, string shipType)
    {
        _field = field;
        _shipType = shipType;
    }
}
class ZeroCountException : Exception
{
    public string _method = "";
    public ZeroCountException(string method)
    {
        _method = method;
    }
}