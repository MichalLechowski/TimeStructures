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
            Time czas1 = new Time(10, 20);
            Time czas2 = new Time(10);
            Time czas3 = new Time(10, 20, 30);
            Console.WriteLine(czas1);
            Console.WriteLine(czas2);
            Console.WriteLine(czas3);

            Time czas4 = new Time(10, 10, 10);
            TimePeriod odcinek = new TimePeriod(26, 59, 10); // godzina 10 + 24h + 2h = 12h + 1h wynikająca z minut = 13h; zostaje 9min i 20sek;
            czas4.Plus(odcinek);
            Console.WriteLine(czas4);

            TimePeriod odcinekC1 = new TimePeriod(10, 10, 10);
            TimePeriod odcinekC2 = new TimePeriod(10, 10);
            TimePeriod odcinekC3 = new TimePeriod(10);
            odcinekC1.Plus(odcinekC2);
            Console.WriteLine(odcinekC1); // 20h,20m,10s

            TimePeriod odcinekC4 = new TimePeriod(czas1, czas2);
            Console.WriteLine(odcinekC4); // 20min różnicy

            //obiekt zostaje utworzony jak przypadkowo na początku lub końcu znajdzie się spacja
            Time czas5 = new Time("     10:30:25    "); 
            Console.WriteLine(czas5);

            Console.WriteLine(czas1.Equals(czas2)); //false, inna wartość minut

            Console.WriteLine(czas1.CompareTo(czas2)); //zwraca 1, bo czas1 jest "większy" od czas2 o 20 minut

            Console.WriteLine(czas1 > czas2); //True, potwierdzenie, że czas1 jest "większy"

            Console.ReadLine();
        }
    }
}
