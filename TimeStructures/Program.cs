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

            Time czas = new Time(10, 10, 10);
            TimePeriod odcinek = new TimePeriod(26, 59, 10);

            czas.Plus(odcinek);

            Console.WriteLine(czas);


            //Time czas = new Time("24:20:20");
            //Time czas1 = new Time(22, 20, 20);
            //TimePeriod odcinekT = new TimePeriod(czas, czas1);
            //TimePeriod odcinekT1 = new TimePeriod(31, 30, 90);
            //TimePeriod odcinekT2 = new TimePeriod(31, 31, 30);
            //Console.WriteLine(odcinekT1.Equals(odcinekT2));
            //Console.WriteLine(odcinekT1 <= odcinekT2);
            //Console.WriteLine(odcinekT);
            //odcinekT2.Plus(odcinekT1);
            //Console.WriteLine(odcinekT2);
            //Console.WriteLine(czas);
            //Console.WriteLine(czas1);
            //Console.WriteLine(czas.Equals(czas1));
            //Console.WriteLine(czas.CompareTo(czas1));
            //Console.WriteLine(czas.Equals(czas));
            //Console.WriteLine(czas1.CompareTo(czas1));

            //Console.WriteLine(czas);
            //czas.Plus(odcinekT);
            //Console.WriteLine(czas);
            //Time.Plus(czas, odcinekT);
            //Console.WriteLine(czas);

            Console.ReadLine();
            
        }
    }
}
