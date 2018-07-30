using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLibrary
{
    /// <summary>
    /// Struktura przechowująca informację o przedziale czasowym wyrażonym w sekundach.
    /// Pozwala na podstawowe manipulacje na strukturze.
    /// </summary>
    public struct TimePeriod: IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <value> Przechowuje informację o liczbie sekund przekazanej w konstruktorze </value>
        public byte Seconds { get; private set; }
        /// <value> Przechowuje informację o liczbie godzin przekazanej w konstruktorze </value>
        public byte Hours { get; private set; }
        /// <value> Przechowuje informację o liczbie minut przekazanej w konstruktorze </value>
        public byte Minutes { get; private set; }
        /// <value> Wewnętrzne przedstawienie przedziału czasowego w postaci łącznej liczby sekund </value>
        public long SecondsTotal { get; private set; }
        
        /// <summary>
        /// Konstruktor umożliwający wygenerowanie przedziału czasowego z dowolną liczbą parametrów 0,1,2 lub3
        /// </summary>
        /// <param name="godziny">Wartość godzin. Domyślna wartość 0.</param>
        /// <param name="minuty">Wartość minut. Domyślna wartość 0</param>
        /// <param name="sekundy">Wartość sekund. Domyślna wartość 0</param>
        public TimePeriod(byte godziny = 0, byte minuty = 0, byte sekundy = 0)
        {
            if (minuty >= 60 || sekundy >= 60)
            {
                throw new FormatException("Niepoprawny zakres parametrów, dozwolone wartości: minuty<0,60), sekundy<0,60)");
            }
            try
            {
                Hours = godziny;
                Minutes = minuty;
                Seconds = sekundy;
                SecondsTotal = Hours * 3600 + Minutes * 60 + Seconds;
            }
            catch (Exception)
            {
                throw new FormatException("Błędny typ jednego z parametrów: godzina, minuta, sekunda.");
            }

        }
        /// <summary>
        /// Konstruktor inicjalizujący strukturę poprzez wyliczenie różnicy czasowej
        /// pomiędzy dwoma strukturami klasy Time
        /// </summary>
        /// <param name="obj1">Struktura klasy Time</param>
        /// <param name="obj2">Struktura klasy Time</param>
        public TimePeriod(Time obj1, Time obj2)
        {
            Hours = (byte)Math.Abs(obj1.Hours - obj2.Hours);
            Minutes = (byte)Math.Abs(obj1.Minutes - obj2.Minutes);
            Seconds = (byte)Math.Abs(obj1.Seconds - obj2.Seconds);
            SecondsTotal = Hours * 3600 + Minutes * 60 + Seconds;
        }
        /// <summary>
        /// Konstruktor inicjalizujący strukturę z czasem przekazanym w formie ciągu znaków.
        /// </summary>
        /// <param name="odcinekCzasu">Parametr typu string w formacie {hh:mm:ss} określający przedział czasowy</param>
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
                SecondsTotal = (Convert.ToByte(tab[0]) * 3600 + Convert.ToByte(tab[1]) * 60 + Convert.ToByte(tab[2]));

                Hours = Convert.ToByte(tab[0]);
                Minutes = Convert.ToByte(tab[1]);
                Seconds = Convert.ToByte(tab[2]);
            }
            catch (FormatException)
            {
                throw new FormatException("Błędny typ jednego z parametrów: godzina, minuta, sekunda.");
            }
        }
        /// <summary>
        /// Przeciążenie metody ToString()
        /// </summary>
        /// <returns>
        /// Zwraca przedział czasowy w formacie {hh:mm:ss}
        /// </returns>
        public override string ToString()
        {
            return $"Odcinek czasowy o długości: {Hours}:{Minutes}:{Seconds}";
        }
        /// <summary>
        /// Metoda umożliwająca dodawanie dwóch struktur klasy TimePeriod
        /// </summary>
        /// <param name="obj1">Odcinek czasu do dodania w postaci struktury czasu klasy TimePeriod</param>
        /// <returns>
        /// Zwraca strukturę klasy TimePeriod o zsumowanych wartościach z obiektów obj1,obj2
        /// </returns>
        public TimePeriod Plus(TimePeriod obj1)
        {
            this.SecondsTotal += obj1.SecondsTotal;
            this.Hours += obj1.Hours;
            this.Minutes += obj1.Minutes;
            this.Seconds += obj1.Seconds;
            return this;
        }
        /// <summary>
        /// Statyczna odmiana metody instancyjnej Plus
        /// </summary>
        /// <param name="obj1">Przedział czasowy w postaci struktury klasy TimePeriod</param>
        /// <param name="obj2">Przedział czasowy w postaci struktury klasy TimePeriod</param>
        /// <returns>
        /// Zwraca struktu klasy TimePeriod na podstawie odwołania do instancyjnej metody Plus
        /// </returns>
        public static TimePeriod Plus(TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.Plus(obj2);
        }
        /// <summary>
        /// Implementacja metody CompareTo() dla obiektów klasy TimePeriod.
        /// Wymagane w celu implementacji IEquatable<Time>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// Zwraca wartość bool na podstawie naturalnej równości/nierówności struktur TimePeriod
        /// </returns>
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
        /// <summary>
        /// Implementacja metody Equals() dla obiektów klasy TimePeriod umożliwająca porównywanie
        /// wartości struktur w naturalny sposób na podstawie łącznej wartości sekund.
        /// wymagane w celu implementacji interfejsu IComparable<Time>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Przeciążenie metody GetHashCode, aby uniknąć kolizji hashcode'ów i wystąpienia fałszywej równości
        /// </summary>
        /// <returns>
        /// Możliwie różny hashcode od pierwotnego obiektu
        /// </returns>
        public override int GetHashCode()
        {
            return (byte)(this.Hours * 17 ^ (this.SecondsTotal));
        }
        /// <summary>
        /// Przeciążenie operatora == w celu umożliwienia implementacji metody Equals,
        /// a co za tym idzie naturalnego porównywania struktur
        /// </summary>
        /// <param name="obj1">Struktura do porównania</param>
        /// <param name="obj2">Struktura porównywana</param>
        /// <returns>
        /// Zwraca wartość bool na podstawie naturalnej równości struktur
        /// </returns>
        public static bool operator == (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.SecondsTotal == obj2.SecondsTotal;
        }
        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Zwraca wartość odwrotną do ==
        /// </returns>
        public static bool operator != (TimePeriod obj1, TimePeriod obj2)
        {
            return !(obj1.SecondsTotal == obj2.SecondsTotal);
        }
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator > (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator < (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator >= (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator <= (TimePeriod obj1, TimePeriod obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }
    }
}