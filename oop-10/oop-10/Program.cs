class P
{
    static void Main()
    {
        // Task01
        string[] months = { "January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December" };
        IEnumerable<string> sumWinMonths = months.Where(n => Equals(n, "January") || Equals(n, "February")
        || Equals(n, "December") || Equals(n, "June") || Equals(n, "July") || Equals(n, "August"))
            .Select(n => n);
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        IEnumerable<string> lengthEqualsN = months.Where(n => n.Length == N).Select(n => n);
        IEnumerable<string> lengthMoreOrEquals4AndContainsU = months.Where(n => n.Length >= 4 
            && n.IndexOf('u') != -1).Select(n => n);
        IEnumerable<string> alphOrder = months.OrderBy(s => s);
        foreach (string month in sumWinMonths) Console.WriteLine(month);
        Console.WriteLine();
        foreach (string month in lengthEqualsN) Console.WriteLine(month);
        Console.WriteLine();
        foreach (string month in alphOrder) Console.WriteLine(month);

        //Task02
        var rand = new Random();
        List<Date> dateList = new();
        for (int i = 0; i < 10; i++) dateList.Add(new Date(rand.Next(1945, 2076), rand.Next(1, 13), 
            rand.Next(1, 28)));
        foreach(var n in dateList) Console.WriteLine(n);
        Console.Write("year = ");
        int year = int.Parse(Console.ReadLine());
        //IEnumerable<Date> certainYearDates = dateList.Where(n => n.getYear() == year).Select(n => n);
        IEnumerable<Date> certainYearDates = from d in dateList where d.getYear() == year select d;
        foreach (Date n in certainYearDates) n.WriteDate();
        Console.Write("month = ");
        int iMonth = int.Parse(Console.ReadLine());
        IEnumerable<Date> certainMonthDates = dateList.Where(n => n.getMonth() == iMonth).Select(n => n);
        foreach (Date n in certainMonthDates) n.WriteDate();
        Console.WriteLine("Date interval");
        IEnumerable<Date> datesInterval = dateList.Where(n => 1900 <= n.getYear() && n.getYear() <= 2000)
            .Select(n => n);
        foreach (Date n in datesInterval) n.WriteDate();
        Console.WriteLine("max date");
        var sortedByDescending = dateList.OrderByDescending(n => n.getYear()).ThenByDescending(n => n.getMonth())
            .ThenByDescending(n => n.getDay()).Select(n => n);
        foreach (Date n in sortedByDescending)
        {
            n.WriteDate();
            break;
        }
        Console.WriteLine("sorted");
        foreach (Date n in sortedByDescending) n.WriteDate();
        Console.Write("day = ");
        int day = int.Parse(Console.ReadLine());
        foreach (Date n in dateList)
        {
            if (n.getDay() == day)
            {
                n.WriteDate();
                break;
            }
        }

        //Task04
        string[] names = { "Анна", "Станислав", "Ольга", "Сева" };
        int[] key = { 1, 4, 5, 7 };
        var sometype = names
        .Join(
        key,
        w => w.Length,
        q => q,
        (w, q) => new
        {
            id = w,
            name = string.Format("{0} ", q),
        });
        foreach (var item in sometype)
            Console.WriteLine(item);

        return;
    }
}