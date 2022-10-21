partial class Printer
{
    public string IAmPrinting(ISwim someobj)
    {
        if (someobj == null) return "";
        else return someobj.ToString();
    }
}

struct myStruct
{
    public int _size = 0;
    public string _name = "John";
    myStruct(int size, string name)
    {
        _size = size;
        _name = name;
    }
}

enum ships
{
    Corvette = 1,
    Sailship,
    Boat
}
class Controller
{
    public int AverageDraught(Container obj)
    {
        if (obj != null) return obj.AverageDraught();
        else 
        {
            throw new NullException("AverageDraught");
        }
    }
    public int AverageNumberOfPlaces(Container obj)
    {
        if (obj != null) return obj.AverageNumberOfPlaces();
        else
        {
            throw new NullException("AverageNumberOfPlaces");
        }
    }
    public void AllVehiclesBasedOnCaptains(Container obj)
    {
        if (obj != null) obj.AllVehiclesBasedOnCaptains();
        else
        {
            throw new NullException("AllVehiclesBasedOnCaptains");
        }
    }
}
class Program
{
    static void Main()
    {
        try
        {
            try
            {
                Container container = new Container();
                var ship1 = new Corvette(500, "St. George", 40, 100);
                var ship2 = new Sailship(2000, "Isabelle", 34, 250);
                var ship3 = new Steamvessel(5000, "St. Maria", 20, 400);
                var ship4 = new Boat(46500, "Адмирал Кузнецов", 40, 1980);

                var excGenerator1 = new Boat(46500, "Адмирал Кузнецов", -40, 1980);
                Corvette excGenerator2 = null;
                container.Add(excGenerator2);
                container.AverageDraught();
                Console.WriteLine(ship1._Name[999]);
                container.Delete(excGenerator2);

                container.Add(ship1);
                container.Add(ship2);
                container.Add(ship3);
                container.Add(ship4);
                container.WriteList();
                Console.WriteLine($"Average draught: {container.AverageDraught()}");
                Console.WriteLine($"Average number of places: {container.AverageNumberOfPlaces()}");
                container.AllVehiclesBasedOnCaptains();
            }
            catch (NullException exc)
            {
                Console.WriteLine($"Попытка передачи пустой ссылки в методе {exc._method}");
                throw;
            }
            catch (ZeroCountException exc)
            {
                Console.WriteLine($"Попытка деления на ноль в методе {exc._method}");
                throw;
            }
            catch (InvalidDataException exc)
            {
                Console.WriteLine($"Ошибка при создании объекта. Неверные данные: {exc._field}, " +
                    $"тип корабля: {exc._shipType}");
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Попытка доступа к памяти за рамками массива");
                throw;
            }
        }
        catch (NullException)
        {
            Console.WriteLine("NullException");
        }
        catch (ZeroCountException)
        {
            Console.WriteLine("ZeroException");
        }
        catch (InvalidDataException)
        {
            Console.WriteLine("InvalidDataException");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("IndexOutOfRangeException");
        }
        catch (Exception)
        {
            Console.WriteLine("Плохо написал, переделывай");
        }
        finally
        {
            Console.WriteLine("Блок finally");
        }
    }
}