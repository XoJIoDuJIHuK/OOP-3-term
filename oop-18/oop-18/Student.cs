class Student
{
    public string _name;
    public int _password;
    public static Random random = new();
    public Student(string name, int password)
    {
        _name = name;
        _password = password;
    }
    public Student() { }
    public void StartTesting(Tutor tutor)
    {
        List<double> grades = new();
        for (int i = 0; i < tutor.testList.Count; i++)
        {
            double grade = 0;
            for (int j = 0; j < tutor.testList[i]._count; j++)
            {
                grade += AnswerQuestion(tutor, i, j);
            }
            grades.Add(grade / tutor.testList[i]._count);
        }
        Console.Write("Grades: ");
        foreach (var g in grades) Console.Write($"{g} ");
        Console.WriteLine();
    }
    public static double AnswerQuestion(Tutor tutor, int testIndex, int questionIndex)
    {
        int numOfAnswers = tutor.testList[testIndex]._questions[questionIndex]._numOfAnswers;
        int numOfRightAnswers = tutor.testList[testIndex]._questions[questionIndex]._numOfRightAnswers;
        List<int> answers = new();
        List<int> availableAnswers = new();
        for (int i = 0; i < numOfAnswers; i++) availableAnswers.Add(i);
        for (int i = 0; i < numOfRightAnswers; i++)
        {
            int answer = random.Next(0, availableAnswers.Count);
            answers.Add(availableAnswers[answer]);
            availableAnswers.RemoveAt(answer);
        }
        return tutor.testList[testIndex]._questions[questionIndex].GetGrade(answers);
    }
}

class AccurateStudent : Student
{
    public AccurateStudent(string name, int password) : base(name, password) { }
    public void StartTesting(Tutor tutor)
    {
        List<double> grades = new();
        for (int i = 0; i < tutor.testList.Count; i++)
        {
            double grade = 0;
            for (int j = 0; j < tutor.testList[i]._count; j++)
            {
                Console.WriteLine($"Answering question {j} of {tutor.testList[i]._count}");
                grade += AnswerQuestion(tutor, i, j);
            }
            grades.Add(grade / tutor.testList[i]._count);
        }
        Console.Write("Grades: ");
        foreach (var g in grades) Console.Write($"{g} ");
        Console.WriteLine();
    }
}