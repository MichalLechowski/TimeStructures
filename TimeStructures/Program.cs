using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Time czas = new Time("20:20:20");
            Time czas1 = new Time(20, 33, 1);
            TimePeriod odcinekT = new TimePeriod(1,10,10);

            //Console.WriteLine(czas);
            //Console.WriteLine(czas1);
            //Console.WriteLine(czas.Equals(czas1));
            //Console.WriteLine(czas.CompareTo(czas1));
            //Console.WriteLine(czas.Equals(czas));
            //Console.WriteLine(czas1.CompareTo(czas1));

            Console.WriteLine(czas);
            czas.Plus(odcinekT);
            Console.WriteLine(czas);
            Time.Plus(czas, odcinekT);
            Console.WriteLine(czas);

            Console.ReadLine();
            
        }
    }
}
