using System.Reflection.Metadata.Ecma335;

class User
{
    public string _string;
    private double _compression;
    private int _position;
    public void Compress(double compression)
    {
        _compression *= compression;
    }
    public void Move(int offset)
    {
        _position += offset;
    }
    public User(int c, int p)
    {
        _string = "";
        _compression = c;
        _position = p;
    }
    public User()
    {
        _string = "";
        _compression = 1;
        _position = 0;
    }
    public void Write()
    {
        Console.WriteLine($"compression = {_compression}, position = {_position}");
    }
    public void DeleteSpaces(Action<User> op) => op(this);
    public void DeletePunctuationMarks(Action<User> op) => op(this);
    public int ReturnNumberOfSpaces(Func<User, int> op) => op(this);
    public bool IsShorterThanTenCharacters(Predicate<User> op) => op(this);
    public void AddQwerty(Action<User> op) => op(this);
}



class EventCallers
{
    public delegate void delegateCompress(double compress);
    public delegate void delegateMove(int offset);
    public event delegateCompress? eventHandlerCompress;
    public event delegateMove? eventHandlerMove;
    public void EventCompress(double compress)
    {
        if (eventHandlerCompress != null)
        {
            eventHandlerCompress(compress);
        }
    }
    public void EventMove(int offset)
    {
        if (eventHandlerMove != null)
        {
            eventHandlerMove(offset);
        }
    }
}

class Program
{
    static void Main()
    {
        Action<User> ActionDeleteSpaces = (User user) =>
        {
            string result = "";
            for (int i = 0; i < user._string.Length; i++) if (user._string[i] != ' ') result += user._string[i];
            user._string = result;
            Console.WriteLine(result);
        };
        Action<User> ActionDeletePunctuationMarks = (User user) =>
        {
            string result = "";
            string marks = ".,?!-";
            for (int i = 0; i < user._string.Length; i++)
            {
                bool mark = false;
                for (int j = 0; j < marks.Length && !mark; j++) if (user._string[i] == marks[j]) mark = true;
                if (!mark) result += user._string[i];
            }
            user._string = result;
            Console.WriteLine(result);
        };
        Func<User, int> FuncReturnNumberOfSpaces = (User user) =>
        {
            int result = 0;
            for (int i = 0; i < user._string.Length; i++) if (user._string[i] == ' ') result++;
            return result;
        };
        Predicate<User> PredicateIsSHorterThanTenCharacters = (User user) =>
        {
            return user._string.Length < 10 ? true : false;
        };
        Action<User> ActionAddQwerty = (User user) =>
        {
            string qwerty = "QWERTY";
            string result = "";
            for (int i = 0, j = 0; i < user._string.Length; i++)
            {
                if (i % 3 == 0 && j < qwerty.Length) result += qwerty[j++];
                result += user._string[i];
            }
            user._string = result;
            Console.WriteLine(result);
        };

        User user = new();
        user._string = "ir!u.i ulf,bvu ,?abupe.ivp hbefjfv";
        Console.WriteLine(user.ReturnNumberOfSpaces(FuncReturnNumberOfSpaces));
        user.DeleteSpaces(ActionDeleteSpaces);
        user.DeletePunctuationMarks(ActionDeletePunctuationMarks);
        if (user.IsShorterThanTenCharacters(PredicateIsSHorterThanTenCharacters)) Console.WriteLine("string is shorter than 10 characters");
        else Console.WriteLine("string is longer than 9 characters");
        user.AddQwerty(ActionAddQwerty);

        User[] users = new User[5];
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new();
        }
        EventCallers eventsFirst = new();
        EventCallers eventsSecond = new();
        eventsFirst.eventHandlerCompress += users[1].Compress;
        eventsFirst.eventHandlerCompress += users[2].Compress;
        eventsFirst.eventHandlerCompress += users[3].Compress;
        eventsFirst.eventHandlerMove += users[0].Move;
        eventsFirst.eventHandlerMove += users[4].Move;
        eventsFirst.EventCompress(0.4);
        eventsFirst.EventMove(5);
        for (int i = 0; i < users.Length; i++)
        {
            users[i].Write();
        }

        Console.WriteLine();
        eventsSecond.eventHandlerCompress += users[1].Compress;
        eventsSecond.eventHandlerCompress += users[2].Compress;
        eventsSecond.eventHandlerMove += users[0].Move;
        eventsSecond.eventHandlerMove += users[1].Move;
        eventsSecond.EventCompress(0.9);
        eventsSecond.EventMove(-13);
        for (int i = 0; i < users.Length; i++)
        {
            users[i].Write();
        }
    }
}