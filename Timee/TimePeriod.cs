using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLibrary
{
    public struct TimePeriod: IEquatable<TimePeriod>, IComparable<TimePeriod>
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
            Hours = (byte)Math.Abs(obj1.Hours - obj2.Hours);
            Minutes = (byte)Math.Abs(obj1.Minutes - obj2.Minutes);
            Seconds = (byte)Math.Abs(obj1.Seconds - obj2.Seconds);
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

        public TimePeriod Plus(TimePeriod obj1)
        {
            this.SecondsTotal += obj1.SecondsTotal;
            this.Hours += obj1.Hours;
            this.Minutes += obj1.Minutes;
            this.Seconds += obj1.Seconds;
            return this;
        }

        public static TimePeriod Plus(TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.Plus(obj2);
        }

        public int CompareTo(TimePeriod other)
        {
            if (this.SecondsTotal > other.SecondsTotal)
            {
                return 1;
            }
            else if (this.SecondsTotal < other.SecondsTotal)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool Equals(TimePeriod other)
        {
            //other jest zawsze TimePeriod, bo jest strukturą
            if (other is TimePeriod && this == (TimePeriod)other)
            {
                return other is TimePeriod && this == (TimePeriod)other;

            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (byte)(this.Hours * 17 ^ (this.SecondsTotal));
        }

        public static bool operator == (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.SecondsTotal == obj2.SecondsTotal;
        }
        public static bool operator != (TimePeriod obj1, TimePeriod obj2)
        {
            return !(obj1.SecondsTotal == obj2.SecondsTotal);
        }
        public static bool operator > (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }
        public static bool operator < (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }
        public static bool operator >= (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }
        public static bool operator <= (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }
    }
}
