using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class programm
    {
        static void Main(string[] args)
        {
            try 
            { 
            Computer computer = new Computer(5.5f, "Игровой", 5000, "rtx3050", "i5-46v37m", 1000, 16, 2);
            Scanner scanner = new Scanner(3.3f, "Позерский", 1500, "A4", "black/white", 18, 3);
            Tablet tablet = new Tablet(0.6f, "IPad", 9999, "IOS 14", 8, 512, "gold", 3);
            tablet.BigSale();
            scanner.Info();
            computer.Info();
            bool k = scanner is Scanner;
            bool o = scanner is Computer;
            Computer aboba = computer as Computer;
            Console.WriteLine("\n" + k + "\n" + o);
            Console.Write("\n\n\n\nВведите имя компьютера: ");
            aboba.name = Console.ReadLine();
            aboba.Info();
            aboba.BigSale();
            Computer comp_office = new Computer(3.5f, "Офисный", 1500, "gt730", "pentium", 1000, 16, 9);
            Scanner dinosaur = new Scanner(7.3f, "Тирекс", 2, "A4", "black/white", 3, 25);
            Tablet nya = new Tablet(0.1f, "Детский", 15, "Воображение", 0, 0, "pink", 3);

            Computer comp_office2 = new Computer(1.5f, "Офисный ноутбук", 2000, "gtx750", "ryzen", 512, 8, 1);
            Scanner dinosaur2 = new Scanner(1.1f, "Чудище", 2000, "A4", "full colored", 25, 2);
            Tablet nya2 = new Tablet(0.7f, "Samsung", 1000, "Android", 3, 64, "grey", 3);
            
            Conteiner cont = new Conteiner();

            cont.AddComp(comp_office);
            cont.AddComp(computer);
            cont.AddComp(comp_office2);
            cont.AddTablet(nya);
            cont.AddTablet(tablet);
            cont.AddTablet(nya2);
            cont.AddScanner(scanner);
            cont.AddScanner(dinosaur);
            cont.AddScanner(dinosaur2);
            cont.ShowList();
           
            cont.Old();

            }
            catch (EmptyException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (LongException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (PriceException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (IndexException e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Logger.FileLogger.WriteLog(e);
            }
            finally
            {
                Console.WriteLine("\n--------------------finally-------------------- \n She'll be right ;)");
            }
            Console.ReadKey();


        }
    }
}
