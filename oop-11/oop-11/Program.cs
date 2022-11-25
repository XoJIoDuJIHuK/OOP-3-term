static class Reflector
{
    static string _fileName = "text.txt";
    public static void GetAssemblyName(Type type)
    {
        string str = "Assembly name: " + type.Assembly.ToString() + '\n';
        File.AppendAllText(_fileName, str);
    }
    public static void PublicConstructorsExist(Type type)
    {
        string str = "This type ";
        bool found = false;
        var constructors = type.GetConstructors();
        foreach (var c in constructors)
        {
            if (c.IsPublic)
            {
                str += "has ";
                break;
            }
        }
        if (!found)
        {
            str += "doesn't have ";
        }
        str += "public constructors\n";
        File.AppendAllText(_fileName, str);
    }
    public static void GetPublicMethods(Type type)
    {
        var methods = type.GetMethods();
        foreach (var m in methods)
        {
            if (m.IsPublic) File.AppendAllText(_fileName, "Public method " + m.Name + '\n');
        }
    }
    public static void GetFields(Type t)
    {
        var fields = t.GetFields();
        var properties = t.GetProperties();
        foreach (var f in fields)
        {
            File.AppendAllText(_fileName, "Field " + f.Name + '\n');
        }
        foreach (var p in properties)
        {
            File.AppendAllText(_fileName, "Property " + p.Name + '\n');
        }
    }
    public static void GetInterfaces(Type t)
    {
        var interfaces = t.GetInterfaces();
        foreach (var i in interfaces)
        {
            File.AppendAllText(_fileName, "Interface " + i.Name + '\n');
        }
    }
    public static void GetMethodsByParameter(Type t, Type p)
    {
        var methods = t.GetMethods();
        foreach (var m in methods)
        {
            var pars = m.GetParameters();
            foreach (var parm in pars)
            {
                if (parm.ParameterType == p)
                {
                    File.AppendAllText(_fileName, "Method with parameter " + p.Name + ": " + m.Name + "\n");
                    break;
                }
            }
        }
    }
    public static void Invoke(A obj, string methodName, string[] pars)
    {
        Type type = obj.GetType();
        var method = type.GetMethod(methodName);
        string p1 = pars[0];
        int p2 = int.Parse(pars[1]);
        object[] parameters = new object[2];
        parameters[0] = p1;
        parameters[1] = p2;
        method?.Invoke(obj, parameters);
    }
    public static T Create<T>(Type type) where T : class
    {
        object newObj = Activator.CreateInstance(type);
        T ret = newObj as T;
        return ret;
    }
}
class A
{
    public static void B(string p1, int p2)
    {
        Console.WriteLine($"type: {p1.GetType()} value: {p1}");
        Console.WriteLine($"type: {p2.GetType()} value: {p2}");
    }
    public string str;
    public A()
    {
        str = "qwerty";
    }
}
//class Program
//{
//    static string GenerateString()
//    {
//        string source = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM 1234567890";
//        var rand = new Random();
//        int length = rand.Next(1, 20);
//        string result = "";
//        for (int i = 0; i < length; i++)
//        {
//            result += source[rand.Next(0, source.Length)];
//        }
//        return result;
//    }
//    static void Main()
//    {
//        Type type = typeof(string);
//        Reflector.PublicConstructorsExist(type);
//        Reflector.GetAssemblyName(type);
//        Reflector.GetPublicMethods(type);
//        Reflector.GetFields(type);
//        Reflector.GetInterfaces(type);
//        Reflector.GetMethodsByParameter(type, typeof(string));
//        //Task1-g
//        A a = new();
//        var pars = File.ReadAllLines("params.txt");
//        Reflector.Invoke(a, "B", pars);
//        pars[0] = GenerateString();
//        Random random = new Random();
//        pars[1] = random.Next().ToString();
//        Reflector.Invoke(a, "B", pars);

//        //Task2
//        Type typePlant = typeof(Plant);
//        Type typeCCollection = typeof(CCollection);
//        Reflector.PublicConstructorsExist(typePlant);
//        Reflector.GetPublicMethods(typeCCollection);
//        //Task3
//        A a1 = new();
//        Console.WriteLine($"a1: {a1.str}");
//        A a2 = Reflector.Create<A>(typeof(A));
//        Console.WriteLine($"a2: {a2.str}");
//    }
//}