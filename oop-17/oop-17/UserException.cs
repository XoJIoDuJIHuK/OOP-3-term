class UserException : Exception
{
    public string _message;
    public UserException(string message) { this._message = message; }
}