using System.Text;

namespace OOP_Lab_1
{
    class Lab_1
    {
        static void Main()
        {
            // 1a 

            bool Bool = true;
            byte Byte = 255;    // [0, 255]
            sbyte SByte = 127;  // [-128, 127]
            char Char = 'A';
            decimal Decimal = 1.23M;    // точность 28-29 знаков
            double Double = 1.23;       // точность 15-17 знаков
            float Float = 1.23f;        // точность 6-9 знаков
            int Int = 1;
            uint UInt = 1;
            nint NInt = 2;
            nuint NUInt = 2;
            long Long = 3;
            ulong ULong = 3;
            short Short = 4;
            ushort UShort = 4;

            //

            Console.WriteLine("bool = {0}, byte = {1}, sbyte = {2}, char = {3}" +
                "\ndecimal = {4}, double = {5}, float = {6}, int = {7}" +
                "\nuint = {8}, nint = {9}, nuint = {10}, long = {11}" +
                "\nulong = {12}, short = {13}, ushort = {14}",
                Bool, Byte, SByte, Char, Decimal, Double, Float, Int, UInt,
                NInt, NUInt, Long, ULong, Short, UShort);

            // 1b

            short ShortNum = 12;        // Неявное
            int IntNum = ShortNum;      // zero extension

            sbyte SByteNum = -4;        // Знаковый бит копируется в добавленные разряды
            ShortNum = SByteNum;        // ff fc

            IntNum = SByteNum;

            Long = IntNum;

            Double = Float;


            double DoubleNum = 1.23;    // Явное
            int DoubleToIntNum = (int)DoubleNum;

            int IntParse = int.Parse("12");

            float FloatParse = float.Parse("12,24");

            double DoubleConvert = Convert.ToDouble(FloatParse);

            float FloatConvert = Convert.ToSingle(DoubleNum);

            // 1c
            Object BoxInt = Int;
            int UnboxInt = (int)BoxInt;

            Object BoxLong = Long;
            long UnboxLong = (long)BoxLong;

            // 1d
            var VarFloat = 1.23f;
            Console.WriteLine($"\nVarFloat = {VarFloat}");

            // 1e
            // int NullInt = null;
            Nullable<int> NullInt = null;
            Console.WriteLine($"\nNullable int = {NullInt}");

            // 1f

            //var IntVal = 1;
            //IntVal = 3.4f; присвоение переменной типа int значения типа float невозможно из-за статической типизации языка
            //компилятор лишь выбирает наиболее подходящий тип в момент инициализации

            // 2a
            string Name = "Aleh";
            string AlsoName = "Aleh";

            if (String.Compare(Name, AlsoName) == 0)
            {
                Console.WriteLine($"\nСтроки {Name} и {AlsoName} идентичны!"); // интерполированные строки
            }
            else
            {
                Console.WriteLine($"\nСтроки {Name} и {AlsoName} различны!");
            }

            // 2b
            string List = "one, two, three, four, five";
            string Copy;
            string Surname = " Tachyla";
            string NameAndSurname = Name + Surname;         // Сцепление
            Copy = NameAndSurname;                          // Копирование
            Console.WriteLine($"\nСтудент: {Copy}");
            Console.WriteLine("\n" + Name.Substring(0, 3)); // Выделение подстроки

            string[] Numbers = List.Split(", ");             // Разделение строки
            Console.Write("\nList of numbers: ");
            foreach (string s in Numbers)
            {
                Console.Write(s + " ");
            }

            string A = "рак";       // Вставка подстроки в заданную позицию
            string B = "Атасия";
            Console.WriteLine("\n\n" + B.Substring(0, 3) + A + B.Remove(0, 3));

            string Del = "Анорак";
            Console.WriteLine("\n" + Del.Replace(A, ""));   // Удаление подстроки

            // 2c
            string Empty = "";
            string Null = null;

            if (String.IsNullOrWhiteSpace(Empty) || String.IsNullOrEmpty(Null))
            {
                Console.WriteLine("\nОбе строки равны null или пустые!");
            }
            else
            {
                Console.WriteLine("\nОдна из строк не null или не пустая!");
            }

            // 2d
            StringBuilder Quote = new StringBuilder(" музыка делает"); // 14
            Quote.Insert(0, "Порой"); // 5
            Quote.Remove(13, 6);
            Quote.Append("творит чудеса."); // 14
            Console.WriteLine("\n" + Quote + "\n");

            // 3a
            int[,] Matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // 3b
            try
            {
                Console.Write("\nNumbers: ");
                foreach (string s in Numbers)
                {
                    Console.Write(s + " ");
                }

                Console.Write("\nВведите позицию: ");
                int Index = Convert.ToInt32(Console.ReadLine());
                if (Index - 1 > Numbers.Length)
                {
                    throw new Exception("Неверный индекс!");
                }
                Console.Write("Введите значение: ");
                string Change = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(Change))
                {
                    throw new Exception("Неверное значение!");
                }

                Numbers[Index - 1] = Change;
                Console.Write("New numbers: ");
                foreach (string s in Numbers)
                {
                    Console.Write(s + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 3c
            Random Rnd = new Random();
            float[][] SArray = new float[3][];
            SArray[0] = new float[2];
            SArray[1] = new float[3];
            SArray[2] = new float[4];

            Console.WriteLine("\n\nСтупенчатый массив: ");
            for (int i = 0; i < SArray.Length; i++)
            {
                for (int j = 0; j < SArray[i].Length; j++)
                {
                    SArray[i][j] = Convert.ToSingle(Math.Round(Rnd.NextDouble() * 5, 2));
                    Console.Write(SArray[i][j] + "\t");
                }
                Console.WriteLine();
            }

            // 3d
            var VarInt = new int[] { 1, 2, 3, 4, 5 };
            var VarStr = "Abcdefg";

            // 4a - 4b 
            (int, string, char, string, ulong) Cortege = (18, "Олег", 'М', "Точило", 13371488);
            Console.WriteLine("\n--------Информация--------");
            Console.WriteLine("Возраст:         " + Cortege.Item1);
            Console.WriteLine("Имя:             " + Cortege.Item2);
            Console.WriteLine("Пол:             " + Cortege.Item3);
            Console.WriteLine("Фамилия:         " + Cortege.Item4);
            Console.WriteLine("Дом. телефон:    " + Cortege.Item5);

            // Частичный вывод
            Console.WriteLine("\n" + Cortege.Item1 + " " + Cortege.Item3 + " " + Cortege.Item4);

            // 4c
            (var a, var b) = (144, "156");
            Console.WriteLine("\n" + a + " " + b);

            // 4d
            var First = (a: 10, b: "20");
            var Second = (a: 10, b: "20");
            if (First == Second)
            {
                Console.WriteLine("\nКортежи равны");
            }
            else
            {
                Console.WriteLine("\nКортежи не равны");
            }

            // 5
            Tuple<int, int, int, char> LocalFunc(int[] num, string str)
            {
                return Tuple.Create(num.Max(), num.Min(), num.Sum(), str[0]);
            }
            int[] ArrToTuple = { 5, 12, 56 };
            string StrToTuple = "ABC";
            Tuple<int, int, int, char> T = LocalFunc(ArrToTuple, StrToTuple);
            Console.WriteLine("\nКортеж: " + T);
        }
    }
}