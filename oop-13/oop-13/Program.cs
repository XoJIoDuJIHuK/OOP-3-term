using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
[DataContract]
[Serializable]
public class Ship
{
    [DataMember]
    public string _Name { get; set; } = "DefaultName";
    public override string ToString()
    {
        return $"Ship {_Name}";
    }
    public Ship()
    {
        _Name = "DefaultName";
    }
}
[DataContract]
[Serializable]
public class Steamvessel : Ship
{
    [DataMember]
    public int _Velocity { get; set; } = -1;
    [XmlIgnore]
    [JsonIgnore]
    [field: NonSerialized]
    public int _PassengersCapacity { get; set; } = -1;
    public Steamvessel(string name)
    {
        var rand = new Random();
        _Name = name;
        _Velocity = rand.Next(1, 100);
        _PassengersCapacity = rand.Next(1, 1000);
    }
    public Steamvessel()
    {
        var rand = new Random();
        _Name = "DefaultName";
        _Velocity = rand.Next(1, 100);
        _PassengersCapacity = rand.Next(1, 1000);
    }
    public override string ToString()
    {
        return $"Steamvessel {_Name}, velocity: {_Velocity}, capacity: {_PassengersCapacity}";
    }
}
class Program
{
    static void Write(Steamvessel? obj, string str)
    {
        Console.WriteLine($"{str} {obj._Name}, скорость: {obj._Velocity}, " +
                $"кол-во пассажиров: {obj._PassengersCapacity}");
    }
    static void Main()
    {
        //бинарный
        Console.WriteLine("Binary");
        //ser
        BinaryFormatter binFormatter = new();
        var Titanic = new Steamvessel("Titanic") { _PassengersCapacity = 999, _Velocity = 9 };
        Write(Titanic, "было");
        using (FileStream stream = new("ship.dat", FileMode.OpenOrCreate))
        {
            binFormatter.Serialize(stream, Titanic);
        }
        //deser
        using (FileStream stream = new("ship.dat", FileMode.OpenOrCreate))
        {
            Steamvessel someShip = (Steamvessel)binFormatter.Deserialize(stream);
            Write(someShip, "стало");
        }
        File.Delete("ship.dat");

        //soap
        Console.WriteLine("\nSOAP");
        SoapFormatter soapFormatter = new();
        //ser
        using (FileStream stream = new("ship.soap", FileMode.OpenOrCreate))
        {
            //Steamvessel Olympia = new Steamvessel("Olympia") { _PassengersCapacity = 999, _Velocity = 9 };
            Write(Titanic, "было");
            soapFormatter.Serialize(stream, Titanic);
        }
        //deser
        using (FileStream stream = new("ship.soap", FileMode.OpenOrCreate))
        {
            Steamvessel someShip = (Steamvessel)soapFormatter.Deserialize(stream);
            Write(someShip, "стало");
        }
        File.Delete("ship.soap");

        //xml
        Console.WriteLine("\nXML");
        Write(Titanic, "было");
        XmlSerializer xs = new(typeof(Steamvessel));
        using (StreamWriter sw = new("ship.xml"))
        {
            xs.Serialize(sw, Titanic);
        }
        using (StreamReader sr = new("ship.xml"))
        {
            var someShip = (xs.Deserialize(sr) as Steamvessel)!;
            Write(someShip, "стало");
        }
        File.Delete("ship.xml");

        //json
        Console.WriteLine("\nJSON");
        using (FileStream fs = new("ship.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<Steamvessel>(fs, Titanic);
            Write(Titanic, "было");
        }

        // чтение данных
        using (FileStream fs = new("ship.json", FileMode.OpenOrCreate))
        {
            Steamvessel? someShip = JsonSerializer.Deserialize<Steamvessel>(fs);
            Write(someShip, "стало");
        }

        File.Delete("ship.json");

        //collection
        Console.WriteLine("\nCollection");
        XmlSerializer xmlSerializer = new(typeof(List<Steamvessel>));
        List<Steamvessel> xmlList = new();
        xmlList.Add(new Steamvessel("Adm. Kuznetsov"));
        xmlList.Add(new Steamvessel("Moskva"));
        xmlList.Add(new Steamvessel("Gnevny"));
        foreach (var s in xmlList) Write(s, "было");
        //ser
        using (FileStream topStream = new("list.xml", FileMode.Create))
        {
            xmlSerializer.Serialize(topStream, xmlList);
        }
        //deser
        using (FileStream topStream = new("list.xml", FileMode.OpenOrCreate))
        {
            List<Steamvessel> someShips = (List<Steamvessel>)xmlSerializer.Deserialize(topStream)!;

            foreach (var item in someShips)
            {
                Write(item, "стало");
            }
        }

        //XPath
        Console.WriteLine("\nXPath");

        XmlDocument xmlDocXPath = new();
        xmlDocXPath.Load("list.xml");

        XmlNode xmlRoot = xmlDocXPath.SelectSingleNode("ArrayOfSteamvessel")!;
        XmlNodeList nodeSteamvessel = xmlRoot.SelectNodes("Steamvessel")!;

        foreach (XmlNode item in nodeSteamvessel)
        {
            Console.WriteLine($"{item.SelectSingleNode("_Name")!.InnerText} " +
                $"{item.SelectSingleNode("_Velocity")!.InnerText}");
        }

        //Linq to XML

        Console.WriteLine("\nLINQ to XML:");
        XElement NewTank(string attrValue, string childElemValue)
        {
            XElement ret = new("TANK");
            ret.Add(new XAttribute("model", attrValue));
            ret.Add(new XElement("PRICE", childElemValue));
            return ret;
        };
        XDocument xmlDoc = new();
        XElement tanks = new("TANK_PARK");
        tanks.Add(NewTank("Maus", "999999989"));
        tanks.Add(NewTank("Pz. Kpfw. 3E", "1000"));
        tanks.Add(NewTank("T-62A", "223435"));
        xmlDoc.Add(tanks);
        xmlDoc.Save("tanksLinq.xml");

        Console.WriteLine("Tanks more expensive than 1000 money:");
        XDocument loadedDoc = XDocument.Load("tanksLinq.xml");
        var tanksList = from t in loadedDoc.Descendants("TANK")
                        where int.Parse(t.Element("PRICE")!.Value) > 1000
                        select t.Attribute("model")!.Value;
        foreach (var t in tanksList) { Console.WriteLine(t); }
    }
}