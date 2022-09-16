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
}