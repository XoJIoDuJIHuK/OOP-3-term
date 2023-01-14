public abstract class AbstractQuestion
{
    public abstract double GetGrade(List<int> answers);
}

public class Question : AbstractQuestion
{
    public string _text;
    public int _numOfAnswers;
    public int _numOfRightAnswers;
    public List<int> _numsOfRightAnswers;
    public Question(string text, int numOfAnswers, List<int> numsOfRightAnswers)
    {
        _text = text;
        _numOfAnswers = numOfAnswers;
        _numOfRightAnswers = numsOfRightAnswers.Count;
        _numsOfRightAnswers = numsOfRightAnswers;
    }
    public Question() { }
    public override double GetGrade(List<int> answers)
    {
        int rightAnswers = 0;
        for (int i = 0; i < answers.Count; i++)
        {
            if (_numsOfRightAnswers.Contains(answers[i])) rightAnswers++;
        }
        return rightAnswers / _numOfRightAnswers;
    }
}

public class QuestionDecorator :AbstractQuestion
{
    protected Question question;

    public string _text
    {
        get
        {
            return question._text;
        }
        set
        {
            question._text = value;
        }
    }
    public int _numOfAnswers
    {
        get
        {
            return question._numOfAnswers;
        }
        set
        {
            question._numOfAnswers = value;
        }
    }
    public int _numOfRightAnswers
    {
        get
        {
            return question._numOfRightAnswers;
        }
        set
        {
            question._numOfRightAnswers = value;
        }
    }
    private List<int> _numsOfRightAnswers
    {
        get
        {
            return question._numsOfRightAnswers;
        }
        set
        {
            question._numsOfRightAnswers = value;
        }
    }
    public QuestionDecorator(string text, int numOfAnswers, List<int> numsOfRightAnswers)
    {
        question = new(text, numOfAnswers, numsOfRightAnswers);
    }
    public QuestionDecorator()
    {
        question = new();
    }

    public override double GetGrade(List<int> answers)
    {
        if (question != null)
        {
            return question.GetGrade(answers);
        }
        else return 0;
    }
}