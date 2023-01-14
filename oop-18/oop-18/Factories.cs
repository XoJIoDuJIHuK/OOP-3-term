class TestFactory : IAbstractFactory
{
    public Test CreateTest(Builder builder)
    {
        var random = new Random();
        int numOfAnswers = 4;
        List<QuestionDecorator> questions = new();
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
        return (new(builder.Class, questions));
    }
}

//class ScienceTestFactory : IAbstractFactory
//{
//    public Test CreateTest()
//    {
//        var random = new Random();
//        int numOfAnswers = 5;
//        List<QuestionDecorator> questions = new();
//        for (int j = 0; j < 3; j++)
//        {
//            int numOfRightAnswers = random.Next(1, numOfAnswers);
//            List<int> availableAnswers = new();
//            List<int> numsOfRightAnswers = new();
//            for (int k = 0; k < numOfAnswers; k++) availableAnswers.Add(k);
//            for (int k = 0; k < numOfRightAnswers; k++)
//            {
//                int answer = random.Next(0, availableAnswers.Count);
//                numsOfRightAnswers.Add(availableAnswers[answer]);
//                availableAnswers.RemoveAt(answer);
//            }
//            questions.Add(new("default text", numOfAnswers, numsOfRightAnswers));
//        }
//        return (new("science", questions));
//    }
//}

//class EnglishTestFactory : IAbstractFactory
//{
//    public Test CreateTest()
//    {
//        var random = new Random();
//        int numOfAnswers = 6;
//        List<QuestionDecorator> questions = new();
//        for (int j = 0; j < 3; j++)
//        {
//            int numOfRightAnswers = random.Next(1, numOfAnswers);
//            List<int> availableAnswers = new();
//            List<int> numsOfRightAnswers = new();
//            for (int k = 0; k < numOfAnswers; k++) availableAnswers.Add(k);
//            for (int k = 0; k < numOfRightAnswers; k++)
//            {
//                int answer = random.Next(0, availableAnswers.Count);
//                numsOfRightAnswers.Add(availableAnswers[answer]);
//                availableAnswers.RemoveAt(answer);
//            }
//            questions.Add(new("default text", numOfAnswers, numsOfRightAnswers));
//        }
//        return (new("english", questions));
//    }
//}