using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
1)      К предыдущей лабораторной работе (л.р. 4) добавьте к существующим
классам перечисление и структуру.
2)      Один из классов сделайте partial и разместите его в разных файлах.
3)     Определить класс-Контейнер (указан в вариантах жирным шрифтом)
для хранения разных типов объектов (в пределах иерархии) в виде
списка или массива (использовать абстрактный тип данных). Классконтейнер должен содержать методы get и set для управления
списком/массивом, методы для добавления и удаления объектов в
список/массив, метод для вывода списка на консоль.
 4)   Определить управляющий класс-Контроллер, который управляет
объектом- Контейнером и реализовать в нем запросы по варианту. При
необходимости используйте стандартные интерфейсы (IComparable,
ICloneable,….)*/
/*  Создать Лабораторию и наполнить ее техникой.
    Найти технику старше заданного срока службы.
    Подсчитать количество каждого вида техники.
    Вывести список техники в порядке убывания цены.
*/
namespace lab4
{
    enum Spisoc
    {
        Comp,
        tablet,
        scan
    }
    struct Stuktura
    {
        public int a;
        public int b;

    }
    partial class Conteiner
    {
        List<Computer> computer = new List<Computer>();
        List<Scanner> scanner = new List<Scanner>();
        List<Tablet> tablet = new List<Tablet>();
        public int countComp = 0;
        public int countScanner = 0;
        public int countTablet = 0;
        public void AddComp(Computer a) { computer.Add(a); countComp++; }
        public void AddScanner(Scanner a) { scanner.Add(a); countScanner++; }
        public void AddTablet(Tablet a) { tablet.Add(a); countTablet++; }
        public void RemoveComp(Computer a) { computer.Remove(a); countComp--; }
        public void RemoveScanner(Scanner a) { scanner.Remove(a); countScanner--; }
        public void RemoveTablet(Tablet a) { tablet.Remove(a); countTablet--; }
        public void ShowList()
        {
            var sortedListComp = computer.OrderByDescending(x => x.cost).ToList();
            var sortedListScan = scanner.OrderByDescending(x => x.cost).ToList();
            var sortedListTabl = tablet.OrderByDescending(x => x.name).ToList();
            Console.WriteLine("\n------------------------------------------------\n");
            Console.WriteLine("кол-во Компьютеров: " + countComp);
            Console.WriteLine("Список Компьютеров");
            foreach (Computer item in sortedListComp)
            {
                Console.WriteLine("\n-----\n"+item.ToString());
            }
            Console.WriteLine("кол-во Сканеров: " + countScanner);
            Console.WriteLine("Список Сканеров");
            foreach (Scanner scn in sortedListScan)
            {
                Console.WriteLine("\n-----\n" + scn.ToString());
            }
            Console.WriteLine("кол-во Планшетов: " + countTablet);
            Console.WriteLine("Список Планшетов");
            foreach (Tablet tab in sortedListTabl)
            {
                Console.WriteLine("\n-----\n" + tab.ToString());
            }
            Console.WriteLine("кол-во Планшетов: " + countTablet);
        }
            
            public void Old()
        {
            Console.Write("\n-------------------------------------------------------------------\nВведите необходимый возраст: ");
            byte a = Convert.ToByte(Console.ReadLine());
            foreach (Computer item in computer)
            {
                if (item.sroki > a)
                    Console.WriteLine("\n-----\n" + item.ToString());
                else
                    continue;
            }
            foreach (Scanner item in scanner)
            {
                if (item.sroki > a)
                    Console.WriteLine("\n-----\n" + item.ToString());
                else
                    continue;
            }
            foreach (Tablet item in tablet)
            {
                if (item.sroki > a)
                    Console.WriteLine("\n-----\n" + item.ToString());
                else
                    continue;
            }


        }


    }
    partial class Controller
    {
        public void Show(Conteiner lib) { lib.ShowList(); }
        public void Price(Conteiner lib) { lib.Old();  }
       
    }
}


