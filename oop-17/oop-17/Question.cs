public class Question
{
    public string _text;
    public int _numOfAnswers;
    public int _numOfRightAnswers;
    private List<int> _numsOfRightAnswers;
    public Question(string text, int numOfAnswers, List<int> numsOfRightAnswers)
    {
        _text = text;
        _numOfAnswers = numOfAnswers;
        _numOfRightAnswers = numsOfRightAnswers.Count;
        _numsOfRightAnswers = numsOfRightAnswers;
    }
    public Question() { }
    public double GetGrade(List<int> answers)
    {
        int rightAnswers = 0;
        for (int i = 0; i < answers.Count; i++)
        {
            if (_numsOfRightAnswers.Contains(answers[i])) rightAnswers++;
        }
        return rightAnswers / _numOfRightAnswers;
    }
}