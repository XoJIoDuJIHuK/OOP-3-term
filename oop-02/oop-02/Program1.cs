partial class Date
{
    private int _year;
    private int _month;
    private int _day;
    readonly int _hash = 0;
    const string _format = "dd/mm/yyyy";
    private string[] _months = {"января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября",
        "октября", "ноября", "декабря"};
    private int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    static int _numberOfObjects = 0;
    static void _numberOfObjectsOutput()
    {
        Console.WriteLine($"Количество объектов: {_numberOfObjects}");
    }
    public void leapCheck(int year)
    {
        if (year % 100 != 0 && year % 4 == 0)
        {
            _daysInMonth[1] = 29;
        }
    }
    public int _hour
    {
        get { return _hour; }
        set { _hour = value; }
    }
    public int _minute
    {
        get { return _minute; }
    }
    public void setYear(int year)
    {
        _year = year;
        leapCheck(year);
    }
    public int getYear()
    {
        return _year;
    }
    public void setMonth(ref int month)
    {
        if (1 < month && month <= 12)
        {
            _month = month;
        }
        else
        {
            Console.WriteLine("Invalid month value\n");
            return;
        }
    }
    public int getMonth()
    {
        return _month;
    }
    public void setDay(int day, out int result)
    {
        if (1 < day && day <= _daysInMonth[_month - 1])
        {
            _day = day;
            result = 0;
        }
        else
        {
            Console.WriteLine("Invalid day value\n");
            result = 0;
            return;
        }
    }
    public int getDay()
    {
        return _day;
    }
    private Date() { _numberOfObjects++; }
    static Date() { _numberOfObjects++; }
    public Date(int year)
    {
        leapCheck(year);
        _year = year;
        _month = 1;
        _day = 1;
        _numberOfObjects++;
    }
    public Date(int year, int month)
    {
        leapCheck(_year);
        if (1 < month && month <= 12)
        {
            _month = month;

        }
        else
        {
            Console.WriteLine("Invalid month value\n");
            return;
        }
        _year = year;
        _day = 1;
        _numberOfObjects++;
    }
    public Date(int year, int month, int day = 1)
    {
        leapCheck(year);
        _year = year;
        if (1 < month && month <= 12)
        {
            _month = month;
        }
        else
        {
            Console.WriteLine("Invalid month value\n");
            return;
        }
        if (1 < day && day <= _daysInMonth[_month - 1])
        {
            _day = day;
        }
        else
        {
            Console.WriteLine("Invalid day value\n");
            return;
        }
        _hash = GetHashCode();
        _numberOfObjects++;
    }
    public void WriteDate(bool format)
    {
        if (format)
        {
            Console.WriteLine($"{_day} {_months[_month - 1]} {_year}");
        }
        else
        {
            Console.WriteLine($"{_day}/{_month}/{_year}");
        }
    }
    public void WriteMonthAndDay()
    {
        Console.WriteLine($"{_day} {_months[_month - 1]}");
    }
}

class Program
{
    static void Main()
    {
        int length = 5;
        Date[] masOfDates = new Date[length];
        for (int y = 2000, m = 2, d = 10, i = 0; i < 5; i++, y += 4, m++, d -= 2)
        {
            masOfDates[i] = new Date(y, m, d);
            //int result = 0;
            //masOfDates[i].setDay(d, out result);
            //masOfDates[i].setMonth(ref m);
            //masOfDates[i].setYear(y);
            masOfDates[i].WriteDate(true);
            masOfDates[i].WriteDate(false);
        }
        Console.Write("Enter year ");
        int destYear = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < length; i++)
        {
            if (masOfDates[i].getYear() == destYear)
            {
                masOfDates[i].WriteMonthAndDay();
            }
        }
        Console.Write("Enter number ");
        int destNumber = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < length; i++)
        {
            if (masOfDates[i].getDay() == destNumber || masOfDates[i].getMonth() == destNumber ||
                masOfDates[i].getYear() == destNumber)
            {
                masOfDates[i].WriteDate(false);
                masOfDates[i].WriteDate(true);
            }
        }
    }
}