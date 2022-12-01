using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;

class Program
{
    public static async void AsyncMet()
    {
        Task<int> taskValue = Task<int>.Factory.StartNew(() => {
            int i = 0;
            for (; i < 300; i++)
            {
                if (i % 100 == 0) Console.WriteLine(i);
                Thread.Sleep(1);
            }
            Console.WriteLine("In task");
            return i;
        });
        Console.WriteLine("Before await");
        int value = await taskValue;
        Console.WriteLine($"After await: res = {value}");
    }
    static void Main()
    {
        //Task1
        Console.WriteLine("--------------------\nTask 1\n--------------------");
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
        int multiplier = 5;
        Task task1 = new(() =>
        {
            int size = 1;
            Stopwatch time = new();
            time.Start();
            List<int> vector = new();
            for (int j = 0; j < size; j++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"\n\nTime Elapsed: {time.Elapsed}");
                    return;
                }
                vector.Add(j);
            }
            for (int j = 0; j < size; j++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"\n\nTime Elapsed: {time.Elapsed}");
                    return;
                }
                vector[j] *= multiplier;
            }
            for (int j = 0; j < size; j++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"\n\nTime Elapsed: {time.Elapsed}");
                    return;
                }
                Console.Write($"{vector[j]} ");
            }
            time.Stop();
            void Exit()
            {
                Console.WriteLine($"\n\nTime Elapsed: {time.Elapsed}");
                return;
            }
        });
        task1.Start();

        Thread.Sleep(1000);
        cancelTokenSource.Cancel();
        Thread.Sleep(1000);

        int id = task1.Id;
        bool comp = task1.IsCompleted;
        TaskStatus status = task1.Status;

        task1.Wait();

        Console.WriteLine("------------Task Status------------");
        Console.WriteLine($"Task Id: {id}");
        Console.WriteLine($"Task Completed: {comp}");
        Console.WriteLine($"Task Status: {status}");
        Console.WriteLine("-----------------------------------");

        //Task2 lmao
        //Task4
        Console.WriteLine("--------------------\nTask 4\n--------------------");
        var tasks4 = new Task<int>[3];
        int Sum(int a, int b) => a + b;
        for (int i = 0; i < tasks4.Length; i++)
        {
            Random random = new();
            tasks4[i] = new(() => Sum(random.Next(1, 100), random.Next(1, 100)));
            tasks4[i].Start();
        }
        Task.WaitAll(tasks4);
        var task4 = new Task(() => { Console.WriteLine($"Sum of results of three tasks: {tasks4[0].Result 
            * tasks4[1].Result - tasks4[2].Result}"); });
        task4.Start();
        task4.Wait();

        //Task5
        //1
        Console.WriteLine("--------------------\nTask 5 part 1\n--------------------");
        Task task5_1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

        Task task5_2 = task5_1.ContinueWith(t =>
            Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

        Task task5_3 = task5_2.ContinueWith(t =>
            Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

        Task task5_4 = task5_3.ContinueWith(t =>
            Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

        task5_1.Start();

        task5_4.Wait();

        //2
        Console.WriteLine("--------------------\nTask 5 part 2\n--------------------");
        Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
        var awaiter = what.GetAwaiter();
        awaiter.OnCompleted(() => {
            int res = awaiter.GetResult();
            Console.WriteLine(res);
        });
        Thread.Sleep(1000);

        //Task6                     буст в 18 раз
        Console.WriteLine("--------------------\nTask 6 parallel\n--------------------");
        Stopwatch sw = Stopwatch.StartNew();
        const int mil7 = 1;
        int[] arrPar = new int[mil7];
        int[] arrNon = new int[mil7];
        Parallel.For(0, 1000, z =>
        {
            Random r = new();
            for (int i = 0; i < mil7; i++) arrPar[i] = (r.Next(0, 10000) / 7);
            int sum = 0;
            foreach (var i in arrPar) sum += i;
            //Console.Write($"{sw.ElapsedMilliseconds} ");
        });
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Restart();
        Console.WriteLine("-----------------------Non-parallel------------------------");
        for (int j = 0; j < 1000; j++)
        {
            Random r = new();
            for (int i = 0; i < mil7; i++) arrNon[i] = (r.Next(0, 10000) / 7);
            int sum = 0;
            foreach (var i in arrNon) sum += i;
            //Console.Write($"{sw.ElapsedMilliseconds} ");
        }
        Console.WriteLine(sw.ElapsedMilliseconds);

        //ну почти втрое
        Console.WriteLine("-----------------------Parallel foreach------------------------");
        sw.Restart();
        int sumTask7 = 0;
        Parallel.ForEach(arrPar, a =>
        {
            sumTask7 += a * 31 / 13 + (int)Math.Sqrt(69);
        });
        Console.WriteLine(sw.ElapsedMilliseconds);

        Console.WriteLine("-----------------------Non-parallel foreach------------------------");
        sw.Restart();
        sumTask7 = 0;
        foreach (var a in arrPar) sumTask7 += a * 31 / 13 + (int)Math.Sqrt(69);
        Console.WriteLine(sw.ElapsedMilliseconds);

        sw.Stop();

        //Task7
        //Console.WriteLine("--------------------\nTask 7\n--------------------");
        //sw.Restart();
        //Parallel.Invoke(() =>
        //{
        //    for (int i = 0; i <= mil7; i++)
        //    {
        //        string str = "";
        //        for (int j = 0; j < new Random().Next(2, 10); j++)
        //        {
        //            str += (char)(new Random().Next(34, 100));
        //        }
        //    }
        //});
        //Console.WriteLine(sw.ElapsedMilliseconds);

        //Task8
        Console.WriteLine("--------------------\nTask 8\n--------------------");
        Store topshop = new Store();
        Provider provider1 = new Provider(1000);
        Provider provider2 = new Provider(1500);
        Provider provider3 = new Provider(200);
        Provider provider4 = new Provider(700);
        Provider provider5 = new Provider(800);
        Customer customer1 = new Customer();
        Customer customer2 = new Customer();
        Customer customer3 = new Customer();
        Customer customer4 = new Customer();
        Customer customer5 = new Customer();
        Customer customer6 = new Customer();
        Customer customer7 = new Customer();
        Customer customer8 = new Customer();
        Customer customer9 = new Customer();
        Customer customer10 = new Customer();

        Task Pr = new Task(() => {
            provider1.toStockUp(topshop, new Appliances($"appliance1"));
            provider2.toStockUp(topshop, new Appliances($"appliance2"));
            provider3.toStockUp(topshop, new Appliances($"appliance3"));
            provider4.toStockUp(topshop, new Appliances($"appliance4"));
            provider5.toStockUp(topshop, new Appliances($"appliance5"));
            topshop.Appliances.CompleteAdding();
        });
        Task Cn = new Task(() => {
            customer1.pickupFromStock(topshop);
            customer2.pickupFromStock(topshop);
            customer3.pickupFromStock(topshop);
            customer4.pickupFromStock(topshop);
            customer5.pickupFromStock(topshop);
            customer6.pickupFromStock(topshop);
            customer7.pickupFromStock(topshop);
            customer8.pickupFromStock(topshop);
            customer9.pickupFromStock(topshop);
            customer10.pickupFromStock(topshop);
        });

        Pr.Start();
        Cn.Start();
        Task.WaitAll(Cn, Pr);

        //Task9
        Console.WriteLine("--------------------\nTask 9\n--------------------");
        AsyncMet();
        Thread.Sleep(10000);
    }
    class Appliances
    {
        public Appliances(string name)
        {
            _name = name;
        }
        private string _name;
        public string Name
        {
            get;
        }
        public override string ToString()
        {
            return _name;
        }
    }

    class Store
    {
        public delegate void ChangeStateOfStore();
        public event ChangeStateOfStore EventStore;
        BlockingCollection<Appliances> listappliances = new BlockingCollection<Appliances>();
        public void getStore()
        {
            foreach (var i in listappliances)
            {
                Console.WriteLine($"Appliance - {i.Name}");
            }
        }
        public BlockingCollection<Appliances> Appliances
        {
            get
            {
                EventStore?.Invoke();
                return listappliances;
            }
        }
    }

    class Provider
    {
        public Provider(int DeliverySpeed)
        {
            _deliverySpeed = DeliverySpeed;
        }
        int _deliverySpeed;
        public void toStockUp(Store store, Appliances appliance)
        {
            if (appliance.Name == "")
            Thread.Sleep(_deliverySpeed);
            store.EventStore += () => Console.WriteLine($"Added to store: {appliance.Name}");
            store.Appliances.Add(appliance);
            store.EventStore -= () => { };
        }

    }

    class Customer
    {
        public void pickupFromStock(Store store)
        {
            if (!store.Appliances.IsCompleted)
            {
                Appliances pickupingApp;
                store.Appliances.TryTake(out pickupingApp, 100);
                store.EventStore += () => Console.WriteLine($"Picked from store: {pickupingApp}");
                store.EventStore -= () => { };
            }
            else Console.WriteLine($"store is empty");
        }
    }
}