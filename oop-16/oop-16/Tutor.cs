class Tutor
{
    private Random random = new();
    public List<Test> testList;
    public Tutor()
    {
        testList = new List<Test>();
    }
    public void CreateTest(Test test)
    {
        testList.Add(test);
    }
    public void CreateDefaultTests()
    {
        string[] classes = { "math", "science", "english" };
        for (int i = 0; i < 3; i++)
        {
            List<Question> questions = new();
            for (int j = 0; j < 3; j++)
            {
                int numOfAnswers = 4;
                int numOfRightAnswers = random.Next(1, numOfAnswers);
                List<int> availableAnswers = new();
                List<int> numsOfRightAnswers = new();
                for (int k = 0; k < numOfAnswers; k++) availableAnswers.Add(k);
                for (int k = 0; k < numOfRightAnswers; k++)
                {
                    int answer = random.Next(0, availableAnswers.Count);
                    numsOfRightAnswers.Add(availableAnswers[answer]);
                    availableAnswers.RemoveAt(answer);
                }
                questions.Add(new("default text", numOfAnswers, numsOfRightAnswers));
            }
            testList.Add(new(classes[i], questions));
        }
    }
    public void PrintAllTests()
    {
        foreach (var t in testList)
        {
            Console.Write($"Test {t._class}:\n");
            foreach(var q in t._questions)
            {
                Console.WriteLine($"question: {q._text}, noa: {q._numOfAnswers}, nora: {q._numOfRightAnswers}");
            }
        }
    }
    public void DeleteTest(int index)
    {
        if (index > 0 && index < testList.Count)
        {
            testList.RemoveAt(index);
        }
        else Console.WriteLine("such index does not exist");
    }
    public void EditTest(int index, Test test)
    {
        if (index > 0 && index < testList.Count)
        {
            testList[index] = test;
        }
        else Console.WriteLine("such index does not exist");
    }
}