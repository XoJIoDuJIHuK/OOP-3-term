//Strategy
using System.Collections;

interface IStrategy
{
    public void Execute(Student student, Tutor tutor);
}
class Context
{
    public IStrategy _strategy;
    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }
    public Context()
    {
        _strategy = new Strategy1();
    }
}

class Strategy1 : IStrategy
{
    public void Execute(Student student, Tutor tutor)
    {
        student.StartTesting(tutor);
    }
}

class Strategy2 : IStrategy
{
    public void Execute(Student student, Tutor tutor)
    {
        if (tutor.testList.Count == 0) return;
        List<double> grades = new();
        double grade = 0;

        Aggregate aggregate = new(tutor.testList[0]._questions);
        Iterator iterator = aggregate.CreateIterator();

        QuestionDecorator q = (QuestionDecorator)iterator.First();
        Console.WriteLine($"Iterator start:\n{q._text}");

        while (!iterator.IsDone())
        {
            q = (QuestionDecorator)iterator.Next();
            Console.WriteLine(q._text);
        }

        for (int j = 0; j < tutor.testList[0]._count; j++)
        {
            grade += Student.AnswerQuestion(tutor, 0, j);
        }
        grades.Add(grade / tutor.testList[0]._count);
        Console.Write("Grades: ");
        foreach (var g in grades) Console.Write($"{g} ");
        Console.WriteLine();
    }
}

//Memento
public class TestMemento
{
    public string _class { get; private set; }
    public List<QuestionDecorator> _questions { get; private set; }
    public int _count { get; private set; }
    public TestMemento(string @class, List<QuestionDecorator> questions)
    {
        _class = @class;
        _questions = questions;
        _count = questions.Count;
    }
}

class TestHistory
{
    public Stack<TestMemento> History { get; private set; }
    public TestHistory()
    {
        History = new Stack<TestMemento>();
    }
}

//Iterator
class Aggregate
{
    private readonly List<QuestionDecorator> _items = new();

    public Aggregate(List<QuestionDecorator> items)
    {
        _items = items;
    }

    public Iterator CreateIterator()
    {
        return new Iterator(this);
    }
    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
    }
}

class Iterator
{
    private readonly Aggregate _aggregate;
    private int _current;

    public Iterator(Aggregate aggregate)
    {
        this._aggregate = aggregate;
    }

    public object First()
    {
        return _aggregate[0];
    }

    public object Next()
    {
        object ret = null;

        _current++;

        if (_current < _aggregate.Count)
        {
            ret = _aggregate[_current];
        }

        return ret;
    }

    public object CurrentItem()
    {
        return _aggregate[_current];
    }

    public bool IsDone()
    {
        return _current >= _aggregate.Count - 1;
    }
}