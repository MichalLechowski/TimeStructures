using System;

namespace TimeLibrary
{
    /// <summary>
    /// Struktura przechowująca czas w formacie hh:mm:ss.
    /// Zawiera podstawową funkcjonalność w zakresie manipulacji strukturą czasu.
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        /// <value> Przechowuje wartość godziny. </value>
        public byte Hours { get; private set; }
        /// <value> Przechowuje wartość minuty. </value>
        public byte Minutes { get; private set; }
        /// <value> Przechowuje wartość sekundy. </value>
        public byte Seconds { get; private set; }

        /// <summary>
        /// Inicjalizuje strukturę Time wywołaną 1, 2 lub 3 parametrami typu byte
        /// </summary>
        /// <param name="godzina">Wartość godziny.</param>
        /// <param name="minuta">Wartość minuty, parametr opcjonalny, domyślna wartość 0</param>
        /// <param name="sekunda">Wartość sekundy, parametr opcjonalny, domyślna wartość 0</param>
        public Time(byte godzina, byte minuta = 0, byte sekunda = 0)
        {
            try
            {
                Hours = Convert.ToByte(godzina % 24);
                Minutes = Convert.ToByte(minuta % 60);
                Seconds = Convert.ToByte(sekunda % 60);
            }
            catch (FormatException)
            {
                throw new FormatException("Błędny typ jednego z parametrów: godzina, minuta, sekunda.");
            }

        }

        /// <summary>
        /// Inicjalizuje strukturę Time wywołaną przez parametr string
        /// </summary>
        /// <param name="czas">Ciąg znaków reprezentujący godzinę w formacie {hh:mm:ss}</param>
        public Time(string czas)
        {
            czas.Trim();
            string[] tab;
            tab = czas.Split(':');

            if (tab.Length != 3)
            {
                throw new FormatException("Niepoprawny format danych, wymagany format {hh:mm:ss}");
            }
            try
            {
                Hours = (byte)(Convert.ToByte(tab[0]) % 24);
                Minutes = (byte)(Convert.ToByte(tab[1]) % 60);
                Seconds = (byte)(Convert.ToByte(tab[2]) % 60);
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
        /// Zwraca godzinę w postaci ciągu znaków w formach {hh:mm:ss}
        /// </returns>
        public override string ToString()
        {
            return $"Aktualna godzina: {Hours}:{Minutes}:{Seconds}";
        }
        /// <summary>
        /// Przeciążenie metody GetHashCode, aby uniknąć kolizji hashcode'ów i wystąpienia fałszywej równości
        /// </summary>
        /// <returns>
        /// Możliwie różny hashcode od pierwotnego obiektu
        /// </returns>
        public override int GetHashCode()
        {
            return Hours.GetHashCode() * 17 ^ (Minutes.GetHashCode() * Seconds.GetHashCode());
        }
        /// <summary>
        /// Przeciążenie globalnej (Object) metody Equals w celu umożliwienia porównywania wartości struktur
        /// w naturalny sposób na podstawie wartości godziny, minuty, sekundy
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// Zwraca wartość bool informującą o naturalnej równości struktur
        /// </returns>
        public override bool Equals(Object other)
        {
            if (other is Time && this == (Time)other)
            {
                return other is Time && this == (Time)other;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Odwołanie metody Equals w odmianie generycznej do globalnej (Object) metody Equals,
        /// wymagane w celu implementacji interfejsu generycznego IEquatable<Time>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// Zwraca wartość bool informującą o naturalnej równości struktur Time
        /// </returns>
        public bool Equals(Time other)
        {
            return this.Equals((object)other);
        }

        public int CompareTo(Time other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds)
            {
                return 0;
            }
            else if (this.Hours > other.Hours)
            {
                return 1;
            }
            else if (this.Hours == other.Hours)
            {
                if (this.Minutes > other.Minutes)
                {
                    return 1;
                }
                else
                {
                    if (this.Minutes == other.Minutes && this.Seconds > other.Seconds)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                return -1;
            }


        }

        /// <summary>
        /// Przeciążenie operatora == w celu umożliwienia implementacji metody Equals,
        /// a co za tym idzie naturalnego porównywania struktur
        /// </summary>
        /// <param name="obj1">Struktura do porównania</param>
        /// <param name="obj2">Struktura porównywana</param>
        /// <returns></returns>
        public static bool operator ==(Time obj1, Time obj2)
        {
            return obj1.Hours == obj2.Hours && obj1.Minutes == obj2.Minutes && obj1.Seconds == obj2.Seconds;
        }
        /// <summary>
        /// Przeciążenie operatora !=.
        /// </summary>
        /// <param name="obj1">Struktura do porównania</param>
        /// <param name="obj2">Struktura porównywana</param>
        /// <returns>
        /// Operator zwraca wartość odwrotną do ==
        /// </returns>
        public static bool operator !=(Time obj1, Time obj2)
        {
            return !(obj1 == obj2);
        }
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator >(Time obj1, Time obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator <(Time obj1, Time obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator >=(Time obj1, Time obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="obj1">Lewa strona nierówności</param>
        /// <param name="obj2">Prawa strona nierówności</param>
        /// <returns>Zwraca wartość bool na podstawie metody CompareTo()</returns>
        public static bool operator <=(Time obj1, Time obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }

        public Time Plus (TimePeriod odcinekCzasowy)
        {
            long totalSeconds = 0;

            totalSeconds = (this.Hours * 3600 + this.Minutes * 60 + this.Seconds + odcinekCzasowy.SecondsTotal);

            this.Hours = (byte)((totalSeconds / 3600) % 24);
            this.Minutes = (byte)((totalSeconds % 3600) / 60);
            this.Seconds = (byte)((totalSeconds % 3600) % 60);
            return this;
        }

        public static Time Plus (Time obj1, TimePeriod obj2)
        {
            return obj1.Plus(obj2);
        }
    }
}