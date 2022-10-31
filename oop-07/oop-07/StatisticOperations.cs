public static class StatisticOperations
{
    public static int SumMinMax(Vector<int> parm1)
    {
        int sum = 0;
        for (int i = 0; i < parm1.getLength(); i++)
        {
            sum += parm1.getMas(i);
        }
        return sum;
    }
    public static int DifMinMax(Vector<int> parm1, Vector<int> parm2)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < parm1.getLength(); i++)
        {
            int value = parm1.getMas(i);
            if (value > max) max = value;
            if (value < min) min = value; 
        }
        for (int i = 0; i < parm2.getLength(); i++)
        {
            int value = parm2.getMas(i);
            if (value > max) max = value;
            if (value < min) min = value;
        }
        return max - min;
    }
    public static int ElemCount(Vector<int> parm1, Vector<int> parm2)
    {
        return parm1.getLength() + parm2.getLength();
    }
    public static string StrCut(this string parm, int index)
    {
        if (index > parm.Length)
        {
            Console.WriteLine("invalid index");
            return "";
        }
        string newString = "";
        for (; index < parm.Length; index++)
        {
            newString += parm[index];
        }
        return newString;
    }
    public static Vector<int> DelPositive(this Vector<int> parm)
    {
        int newLength = 0;
        for (int i = 0; i < parm.getLength(); i++)
        {
            if (parm.getMas(i) <= 0) newLength++;
        }
        Vector<int> newVector = new Vector<int>(newLength);
        for (int i = 0, j = 0; i < parm.getLength(); i++)
        {
            if (parm.getMas(i) <= 0)
            {
                newVector.setMas(j, parm.getMas(i));
                j++;
            }
        }
        return newVector;
    }
}