class Program
{
    static void Main()
    {
        try
        {
            StudentPrototype prototype = new ConcreteStudent("Oleg", 1111);
            StudentPrototype clone = prototype.Clone();

            MathTestFactory mtf = new();
            ScienceTestFactory stf = new();
            EnglishTestFactory etf = new();
            BuilderCreate creator = new();
            BuilderDelete deletor = new();
            BuilderEdit editor = new();
            BuilderPrint printer = new();

            creator.DoSomething(-1, mtf.CreateTest(), Tutor.GetInstance());
            creator.DoSomething(-1, stf.CreateTest(), Tutor.GetInstance());
            creator.DoSomething(-1, etf.CreateTest(), Tutor.GetInstance());

            //deletor.DoSomething(-1, null, Tutor.GetInstance());

            editor.DoSomething(1, new Test("some class", new List<Question>()), Tutor.GetInstance());

            printer.DoSomething(-1, null, Tutor.GetInstance());

            Student student = new("dafault", 1111);
            bool studentRegistered = false;
            bool enteredSystem = false;
            string input;

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
                                    student.StartTesting(Tutor.GetInstance());
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