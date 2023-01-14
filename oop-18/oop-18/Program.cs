class Program
{
    static void Main()
    {
        try
        {
            StudentPrototype prototype = new ConcreteStudent("Oleg", 1111);
            StudentPrototype clone = prototype.Clone();

            TestFactory factory = new();
            BuilderMath bm = new();
            BuilderScience bs = new();
            BuilderEnglish be = new();

            Tutor.GetInstance().testList.Add(factory.CreateTest(bm));
            Tutor.GetInstance().testList.Add(factory.CreateTest(bs));
            Tutor.GetInstance().testList.Add(factory.CreateTest(be));
            
            BuilderDelete deletor = new();
            BuilderEdit editor = new();
            BuilderPrint printer = new();

            printer.DoSomething(-1, null, Tutor.GetInstance());

            Context context = new(new Strategy2());

            //creator.DoSomething(-1, mtf.CreateTest(), Tutor.GetInstance());
            //creator.DoSomething(-1, stf.CreateTest(), Tutor.GetInstance());
            //creator.DoSomething(-1, etf.CreateTest(), Tutor.GetInstance());

            context._strategy.Execute(new(), Tutor.GetInstance());

            TestHistory history = new();
            history.History.Push(Tutor.GetInstance().testList[1].Savestate());

            //deletor.DoSomething(-1, null, Tutor.GetInstance());

            editor.DoSomething(1, new Test("some class", new List<QuestionDecorator>()), Tutor.GetInstance());

            printer.DoSomething(-1, null, Tutor.GetInstance());

            Tutor.GetInstance().testList[1].Restate(history.History.Pop());
            printer.DoSomething(-1, null, Tutor.GetInstance());

            Student student = new("dafault", 1111);
            AccurateStudent accStudent = new("accurate student", 0000);
            bool studentRegistered = false;
            bool enteredSystem = false;
            string input;

            return;

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
                                accStudent = new(name, password);
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
                                    accStudent.StartTesting(Tutor.GetInstance());
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