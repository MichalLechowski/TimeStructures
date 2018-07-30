using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLibrary
{
    public struct TimePeriod
    {
        public byte Seconds { get; private set; }
        public byte Hours { get; set; }
        public byte Minutes { get; set; }
        public long SecondsTotal { get; set; }
        
        public TimePeriod(byte godziny = 0, byte minuty = 0, byte sekundy = 0)
        {
            Hours = godziny;
            Minutes = minuty;
            Seconds = sekundy;
            SecondsTotal = Hours * 3600 + Minutes * 60 + Seconds;
        }

        public TimePeriod(Time obj1, Time obj2)
        {
            Hours = (byte)(obj1.Hours - obj2.Hours);
            Minutes = (byte)(obj1.Minutes - obj2.Minutes);
            Seconds = (byte)(obj1.Seconds - obj2.Seconds);
            SecondsTotal = Hours * 3600 + Minutes * 60 + Seconds;
        }

        public TimePeriod(string odcinekCzasu)
        {
            odcinekCzasu.Trim();
            string[] tab;
            tab = odcinekCzasu.Split(':');

            if (tab.Length > 3)
            {
                throw new FormatException("Niepoprawny format danych, wymagany format {hh:mm:ss}");
            }
            try
            {
                SecondsTotal = (byte)(Convert.ToByte(tab[0]) * 3600 + Convert.ToByte(tab[1]) * 60 + Convert.ToByte(tab[2]));

                Hours = Convert.ToByte(tab[0]);
                Minutes = Convert.ToByte(tab[1]);
                Seconds = Convert.ToByte(tab[2]);
            }
            catch (FormatException)
            {
                throw new FormatException("Błędny typ jednego z parametrów: godzina, minuta, sekunda.");
            }
        }

        public override string ToString()
        {
            return $"Odcinek czasowy o długości: {Hours}, {Minutes}, {Seconds}";
        }
    }
}
