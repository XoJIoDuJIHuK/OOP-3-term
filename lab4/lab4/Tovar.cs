using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab4
{
    abstract class Tovar
    {
        public abstract int cost { get; set; }
        public virtual void BigSale()
        {
            if (cost <3)
            {
                Console.WriteLine("Акция. Цена 3 буна");
            }
            else Console.WriteLine("Акции нету(");
        }
    }
    class Technique : Tovar
    {
       
        public float weight { get; set; }
        public string name { get; set; }
        
        public override int cost { get; set; }
       
        public override void BigSale()
        {
            if (name == "Негр")
            {
                Console.WriteLine("Негры сегодня на акции 2 по цене 3-х");
            }
            else Console.WriteLine("Акции нету(");
        }
        public Technique(float weight, string name, int cost)
        {
            this.weight = weight;
            this.name = name;
            this.cost = cost;
           
        }
        
    }
    class Scanner : Technique, IPringtingDevice {



        public Scanner(float weight, string name, int cost, string format, string color, int speed, int sroki) : base(weight, name, cost)
        {
            this.weight = weight;
            this.sroki = sroki; 
            this.color = color;
            this.cost = cost;
            this.speed = speed;
            this.format = format;
            this.name = name;
            
        }
        

        public string format { get; set; }
        public string color { get; set; }
        public int speed { get; set; }
        public int sroki { get; set; }

        public override string ToString()
        {
            return "Name: " + name + "\nВес: " + weight + "\nЦена: " + cost + "\nColor: " + color + "\nFormat: " + format + "\nSpeed: " + speed;
        }
        public void Info()
        {
            Console.WriteLine(ToString());
        }

    }
    class Computer : Technique {
        public string video_card;
        public string processor;
        public int memory;
        public int ozu;
        public int sroki;

        public Computer(float weight, string name, int cost, string video_card, string proccessor, int memory, int ozu,int sroki) : base(weight, name, cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
            this.processor = proccessor;
            this.memory = memory;
            this.ozu = ozu;
            this.video_card = video_card;
            this.sroki = sroki;

        }

        public override void BigSale()
        {
            if (name == "Игровой ноутбук"||name == "игровой"||name =="Gaming")
            {
                
                Process.Start(new ProcessStartInfo("https://youtu.be/fyJErNQDLjM?t=6" + "") { UseShellExecute = true });
            }
            else Console.WriteLine("Акции нету(");
        }
        public override string ToString()
        {
            return "Name: " + name + "\nВес: " + weight + "\nЦена: " + cost + "\nVide card: " + video_card + "\nProcessor: " + processor + "\nMemory: " + memory+"\nRAM: "+ozu;
        }
        public void Info()
        {
            Console.WriteLine("\n------------Computer--------------\n"+ToString());
        }
    }
    sealed class Tablet: Technique {
        public int grz;
        public string os;
        public int ozu;
        public int memory;
        public string color;
        public int sroki;


        public Tablet(float weight, string name, int cost, string os, int ozu, int memory, string color, int sroki) : base(weight, name, cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
            this.os = os;
            this.ozu=ozu;
            this.memory=memory;
            this.color=color;
            this.sroki = sroki;
        }

        public override void BigSale()
        {
            if (name == "IPad")
            {
                Console.WriteLine("Ipad по скидке");
            }
            else Console.WriteLine("Акции нету(");
        }
        public override string ToString()
        {
            return "Name: " + name + "\nВес: " + weight + "\nЦена: " + cost  + "\nMemory: " + memory + "\nRAM: " + ozu;
        }
        public void Info()
        {
            Console.WriteLine("\n------------Computer--------------\n" + ToString());
        }
    }
     static class Printer
    {
        public static void IAmPrinting(Tovar document)
        {
            Console.WriteLine("--------------------------------------\n" + document.GetType());
            Console.WriteLine(document.ToString());
        }

    //    class X

    //public X() { }          //к-ры не наслед.
    //    public X(int key) { }
    //    class Y : X

    //public Y(int key) { }
    //    public Y() : base(125) { }
    //    void main()

    //Y y0 = new Y();         //авто- вызов к-р базового класса без парам
    //    Y y1 = new Y(125);

    }
}
