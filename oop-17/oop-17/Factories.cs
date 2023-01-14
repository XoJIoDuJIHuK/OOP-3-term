using System;

class MathTestFactory : IAbstractFactory
{
    public Test CreateTest()
    {
        var random = new Random();
        int numOfAnswers = 4;
        List<Question> questions = new();
        for (int j = 0; j < 3; j++)
        {
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
        return (new("math", questions));
    }
}

class ScienceTestFactory : IAbstractFactory
{
    public Test CreateTest()
    {
        var random = new Random();
        int numOfAnswers = 5;
        List<Question> questions = new();
        for (int j = 0; j < 3; j++)
        {
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
        return (new("science", questions));
    }
}

class EnglishTestFactory : IAbstractFactory
{
    public Test CreateTest()
    {
        var random = new Random();
        int numOfAnswers = 6;
        List<Question> questions = new();
        for (int j = 0; j < 3; j++)
        {
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
        return (new("english", questions));
    }
}