partial class Date
{
    // override object.Equals
    public bool Equals(Date obj)
    {
        //       
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237  
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        if (_year == obj._year && _month == obj._month && _day == obj._day)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return (_year % 100) * (_month % 7) + (_day % 11);
    }

    public override string ToString()
    {
        return ($"{_year} {_month} {_day}");
    }
}