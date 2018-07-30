using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLibrary;

namespace UnitTestTime
{
    [TestClass]
    public class UnitTest1
    {
        #region TimeTest
        [DataTestMethod]
        [DataRow((byte)1, (byte)2, (byte)3, (byte)1, (byte)2, (byte)3)]
        [DataRow((byte)5, (byte)10, (byte)15, (byte)5, (byte)10, (byte)15)]

        public void Konstruktor_Trojargumentowy_OK(
            byte godzina, byte minuta, byte sekunda,
            byte expectedGodzina, byte expectedMinuta, byte expectedSekunda)
        {
            //act
            Time czas = new Time(godzina, minuta, sekunda);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)20, (byte)10, (byte)20, (byte)0)]
        [DataRow((byte)20, (byte)40, (byte)20, (byte)40, (byte)0)]
        public void Konstruktor_Dwuargumentowy_OK(
        byte godzina, byte minuta,
        byte expectedGodzina, byte expectedMinuta, byte expectedSekunda)
        {
            //act
            Time czas = new Time(godzina, minuta);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)10, (byte)0, (byte)0)]
        [DataRow((byte)20, (byte)20, (byte)0, (byte)0)]
        public void Konstruktor_Jednoargumentowy_OK(
           byte godzina,
           byte expectedGodzina, byte expectedMinuta, byte expectedSekunda)
        {
            //act
            Time czas = new Time(godzina);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
        }

        [TestMethod]
        [DataRow(25, 30, 10)]
        [DataRow(20, 70, 10)]
        [DataRow(10, 30, 70)]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_BlednaSkladowaGodziny_WyjatekArgumentException(byte godzina, byte minuta, byte sekunda)
        {
            Time t2 = new Time(godzina, minuta, sekunda);
        }

        //Zmiana -> konstruktor nie pozwala na niepoprawne składowe godziny, test nie ma już sensu
        //[DataTestMethod]
        //[DataRow((byte)25, (byte)61, (byte)65, (byte)1, (byte)1, (byte)5)]
        //[DataRow((byte)30, (byte)70, (byte)80, (byte)6, (byte)10, (byte)20)]

        //public void Konstructor_Trojargumentowy_Modulo_OK(
        //   byte godzina, byte minuta, byte sekunda,
        //   byte expectedGodzina, byte expectedMinuta, byte expectedSekunda)
        //{
        //    //act
        //    Time czas = new Time(godzina, minuta, sekunda);

        //    //assert
        //    Assert.AreEqual(expectedGodzina, czas.Hours);
        //    Assert.AreEqual(expectedMinuta, czas.Minutes);
        //    Assert.AreEqual(expectedSekunda, czas.Seconds);
        //}

        [DataTestMethod]
        [DataRow("20:10:5", (byte)20, (byte)10, (byte)5)]
        [DataRow("          20:10:5        ", (byte)20, (byte)10, (byte)5)]
        public void Konstruktor_string_OK(
            string godzina, byte expectedGodzina, byte expectedMinuta, byte expectedSekunda)
        {
            //act
            Time czas = new Time(godzina);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
        }

        [DataTestMethod]
        [DataRow("20:10:5:A")]
        [DataRow("20:10:10:2")]
        [ExpectedException(typeof(FormatException))]
        public void Konstruktor_string_NiepoprawnyFormatDanychException(
           string godzina)
        {
            //act
            Time czas = new Time(godzina);

        }


        [TestMethod]
        public void Equals_OK()
        {
            Time czas1 = new Time(1, 2, 3);
            Time czas2 = new Time(1, 2, 3);
            Time czas3 = new Time(1, 3, 3);
            Time czas4 = new Time(2, 3, 3);
            Time czas5 = new Time(2, 3, 4);
            Assert.AreEqual(czas1, czas2);
            Assert.AreNotEqual(czas2, czas3);
            Assert.AreNotEqual(czas3, czas4);
            Assert.AreNotEqual(czas4, czas5);
        }

        [TestMethod]
        public void CompareTo_OK()
        {
            Time czas1 = new Time(20, 20, 20);
            Time czas2 = new Time(20, 20, 21);
            Time czas3 = new Time(20, 21, 21);
            Time czas4 = new Time(21, 21, 21);
            Time czas5 = new Time(21, 21, 21);

            int result = czas1.CompareTo(czas2);
            Assert.IsTrue(result == -1);
            result = czas2.CompareTo(czas3);
            Assert.IsTrue(result == -1);
            result = czas4.CompareTo(czas3);
            Assert.IsTrue(result == 1);
            result = czas4.CompareTo(czas5);
            Assert.IsTrue(result == 0);
            result = czas5.CompareTo(czas4);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void Plus_OK()
        {
            Time czas1 = new Time(10, 10, 10);
            Time czas2 = new Time(10, 10, 10);
            TimePeriod odcinekCzasowy = new TimePeriod(10, 10, 10);
            TimePeriod odcinekCzasowy2 = new TimePeriod(26, 60, 10);
            Time temp;

            temp = czas1.Plus(odcinekCzasowy);

            Assert.IsTrue(temp.Hours == 20);
            Assert.IsTrue(temp.Minutes == 20);
            Assert.IsTrue(temp.Seconds == 20);

            temp = czas2.Plus(odcinekCzasowy2);

            Assert.IsTrue(temp.Hours == 13);
            Assert.IsTrue(temp.Minutes == 10);
            Assert.IsTrue(temp.Seconds == 20);


        }

        #endregion
    }
}
