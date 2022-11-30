using System.Diagnostics;
class Program
{
    static void DoItOneByOne()
    {
        Mutex mutex = new();

        Thread Nech_Thread = new(Print_Nech);
        Thread Ch_Thread = new(Print_Ch);
        Ch_Thread.Start();
        Nech_Thread.Start();

        void Print_Nech()
        {
            for (int i = 0; i < _n; i++)
            {
                mutex.WaitOne();

                if (i % 2 != 0)
                {
                    Console.Write($"{i} ");
                }
                mutex.ReleaseMutex();
                Thread.Sleep(100);
            }
        }

        void Print_Ch()
        {
            for (int i = 0; i < _n; i++)
            {
                mutex.WaitOne();

                if (i % 2 == 0)
                {
                    Console.Write($"{i} ");
                }
                mutex.ReleaseMutex();
                Thread.Sleep(100);
            }
        }
    }
    static int _n;
    static Mutex _mutex = new();
    static void ChetTaskb1()
    {
        _mutex.WaitOne();
        for (int i = 0; i < _n; i++) if (i % 2 == 0) Console.Write($"{i} ");
        _mutex.ReleaseMutex();
    }
    static void NechetTaskb1()
    {
        _mutex.WaitOne();
        for (int i = 0; i < _n; i++) if (i % 2 == 1) Console.Write($"{i} ");
        _mutex.ReleaseMutex();
    }
    static void Main()
    {
        //Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет,
        //время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.

        var allProcesses = Process.GetProcesses();
        Console.Write("{0,-10}", "ID:");
        Console.Write("{0,-30}", "Name:");
        Console.Write("{0,-10}", "Priority:");
        Console.Write("{0,-11}", "Responding:");
        Console.Write("{0,-25}", "StartTime:");
        Console.Write("{0,-25}", "TotalTime:\n");
        foreach (var process in allProcesses)
        {
            Console.Write("{0,-10}", $"{process.Id}");
            Console.Write("{0,-30}", $"{process.ProcessName}");
            Console.Write("{0,-10}", $"{process.BasePriority}");
            Console.Write("{0,-11}", $"{process.Responding}");
            try
            {
                Console.Write("{0,-25}", $"{process.StartTime} ");
                Console.Write("{0,-25}", $"{process.TotalProcessorTime}");
            }
            catch
            {
                Console.WriteLine("process start and total time is denied");
            }
            Console.Write('\n');
        }

        //Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
        //загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.

        var thisAppDomain = Thread.GetDomain();
        Console.WriteLine($"\nName:  {thisAppDomain.FriendlyName}");
        Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation}");
        Console.WriteLine("Assemblies:");
        foreach (var item in thisAppDomain.GetAssemblies())
        {
            Console.WriteLine("    " + item.FullName.ToString());
        }

        //НЕ РАСКОММЕНТИРОВАТЬ
        //AppDomain newDomain = AppDomain.CreateDomain("qwerty");
        //newDomain.Load("System.Private.CoreLib");
        //AppDomain.Unload(newDomain);


        //Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для задержки)
        //и записи в файл и на консоль простых чисел от 1 до n (задает пользователь). Вызовите методы
        //управления потоком (запуск, приостановка, возобновление и т.д.) Во время выполнения выведите
        //информацию о статусе потока, имени, приоритете, числовой идентификатор и т.д.

        Thread NumbersThread = new(PrintS1mpleNumbers);
        NumbersThread.Start(42);
        Thread.Sleep(1000);

        //NumbersThread.Suspend();      НЕ РАСКОММЕНТИРОВАТЬ

        Console.WriteLine("\n--------------------");
        Console.WriteLine("Статус:   " + NumbersThread.ThreadState);
        Thread.Sleep(100);
        Console.WriteLine("Приоритет:   " + NumbersThread.Priority);
        Thread.Sleep(100);
        Console.WriteLine("Имя потока:  " + NumbersThread.Name);
        Thread.Sleep(100);
        Console.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
        Console.WriteLine("---------------------");
        Thread.Sleep(1000);

        //NumbersThread.Resume();       НЕ РАСКОММЕНТИРОВАТЬ

        Thread.Sleep(2000);
        void PrintS1mpleNumbers(object? num)
        {
            int n = (int)num;
            Console.Write("1 ");
            for (int i = 2; i <= n; i++)
            {
                if (IsS1mple(i)) Console.Write($"{i} ");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
        bool IsS1mple(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
            return true;
        }




        ///4. созд 2 потока:
        /// исп. средства синхронизации орган. работу потоков: 
        /// вывод сначала чет, потом нечет 
        /// послед. вывод 1 чет 1 нечет
        //Создайте два потока. Первый выводит четные числа, второй нечетные до n и записывают их в
        //общий файл и на консоль. Скорость расчета чисел у потоков – разная.
        //  a.Поменяйте приоритет одного из потоков.
        //  b.Используя средства синхронизации организуйте работу потоков, таким образом, чтобы:
        //      1.выводились сначала четные, потом нечетные числа.
        //      2.последовательно выводились одно четное, другое нечетное.

        _n = 50;
        Thread thrChetb1 = new(ChetTaskb1);
        thrChetb1.Start();
        thrChetb1.Priority = ThreadPriority.Highest;//пункт А
        Thread thrNechetb1 = new(NechetTaskb1);
        thrNechetb1.Start();
        Thread.Sleep(1000);
        Console.WriteLine();

        DoItOneByOne();
        Thread.Sleep(10000);
        Console.WriteLine();

        //5. реализ. задачу на основе класса Timer
        //Каждую секунду вызывает WhatTimeIsIt

        TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);
        Timer timer = new Timer(timerCallback, null, 0, 1000);
        Thread.Sleep(5000);

        void WhatTimeIsIt(object obj)
        {
            Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
        }
    }
}