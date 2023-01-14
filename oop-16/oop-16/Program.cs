class Program
{
    static void Main()
    {
        Tutor tutor = new();
        tutor.CreateDefaultTests();
        tutor.DeleteTest(-1);
        tutor.EditTest(1, new Test("some class", new List<Question>()));
        tutor.PrintAllTests();
        Student student = new("dafault", 1111);
        bool studentRegistered = false;
        bool enteredSystem = false;
        string input;
        try
        {
            while (true)
            {
                Console.Write("Enter something: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "sign in":
                        {
                            if (!enteredSystem) enteredSystem = true;
                            else throw new UserException("cannot enter system if already entered");
                            break;
                        }
                    case "sign out":
                        {
                            if (enteredSystem) enteredSystem = false;
                            else throw new UserException("cannot leave system if already left");
                            break;
                        }
                    case "register":
                        {
                            if (enteredSystem)
                            {
                                Console.Write("Enter name: ");
                                string name = Console.ReadLine();
                                Console.Write("Enter password: ");
                                int password = int.Parse(Console.ReadLine());
                                student = new(name, password);
                                studentRegistered = true;
                            }
                            else throw new UserException("cannot registering signing in");
                            break;
                        }
                    case "solve all tests":
                        {
                            if (enteredSystem)
                            {
                                if (studentRegistered)
                                {
                                    student.StartTesting(tutor);
                                }
                                else throw new UserException("cannot solve tests without student");
                            }
                            else throw new UserException("cannot solve tests without signing in");
                            break;
                        }
                }
            }
        }
        catch (UserException e)
        {
            Console.WriteLine(e._message);
        }
    }
}