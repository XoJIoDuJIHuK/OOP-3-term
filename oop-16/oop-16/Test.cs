class Test
{
    public string _class;
    public List<Question> _questions;
    public int _count;
    public Test(string @class, List<Question> questions)
    {
        _class = @class;
        _questions = questions;
        _count = questions.Count;
    }
}