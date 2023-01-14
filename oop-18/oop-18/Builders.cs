class BuilderCreate
{
    public void DoSomething(int index, Test test, Tutor tutor)
    {
        tutor.testList.Add(test);
    }
}

class BuilderMath : Builder
{
    public string Class = "math";
}

class BuilderScience : Builder
{
    public string Class = "science";
}

class BuilderEnglish : Builder
{
    public string Class = "english";
}

class BuilderDelete
{
    public void DoSomething(int index, Test test, Tutor tutor)
    {
        if (index > 0 && index < tutor.testList.Count)
        {
            tutor.testList.RemoveAt(index);
        }
        else throw new UserException("such index does not exist");
    }
}

class BuilderPrint
{
    public void DoSomething(int index, Test test, Tutor tutor)
    {
        foreach (var t in tutor.testList)
        {
            Console.Write($"Test {t._class}:\n");
            foreach (var q in t._questions)
            {
                Console.WriteLine($"question: {q._text}, noa: {q._numOfAnswers}, nora: {q._numOfRightAnswers}");
            }
        }
    }
}

class BuilderEdit
{
    public void DoSomething(int index, Test test, Tutor tutor)
    {
        if (index > 0 && index < tutor.testList.Count)
        {
            tutor.testList[index] = test;
        }
        else throw new UserException("such index does not exist");
    }
}