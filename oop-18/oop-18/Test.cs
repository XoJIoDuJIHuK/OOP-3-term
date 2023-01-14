public class Test
{
    public string _class;
    public List<QuestionDecorator> _questions;
    public int _count;
    public Test(string @class, List<QuestionDecorator> questions)
    {
        _class = @class;
        _questions = questions;
        _count = questions.Count;
    }

    public TestMemento Savestate()
    {
        return new TestMemento(_class, _questions);
    }
    public void Restate(TestMemento tm)
    {
        _class = tm._class;
        _questions = tm._questions;
        _count= tm._count;
    }
}