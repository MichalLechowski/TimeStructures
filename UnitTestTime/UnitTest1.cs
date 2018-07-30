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

        public void Time_Konstruktor_Trojargumentowy_OK(
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
        public void Time_Konstruktor_Dwuargumentowy_OK(
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
        public void Time_Konstruktor_Jednoargumentowy_OK(
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
        public void Time_Konstruktor_BlednaSkladowaGodziny_WyjatekArgumentException(byte godzina, byte minuta, byte sekunda)
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
        public void Time_Konstruktor_string_OK(
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
        public void Time_Konstruktor_string_NiepoprawnyFormatDanychException(
           string godzina)
        {
            //act
            Time czas = new Time(godzina);

        }


        [TestMethod]
        public void Time_Equals_OK()
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
        public void Time_CompareTo_OK()
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
        public void Time_Plus_OK()
        {
            Time czas1 = new Time(10, 10, 10);
            Time czas2 = new Time(10, 10, 10);
            TimePeriod odcinekCzasowy = new TimePeriod(10, 10, 10);
            TimePeriod odcinekCzasowy2 = new TimePeriod(26, 59, 10);
            Time temp;

            temp = czas1.Plus(odcinekCzasowy);

            Assert.IsTrue(temp.Hours == 20);
            Assert.IsTrue(temp.Minutes == 20);
            Assert.IsTrue(temp.Seconds == 20);

            temp = czas2.Plus(odcinekCzasowy2);

            Assert.IsTrue(temp.Hours == 13);
            Assert.IsTrue(temp.Minutes == 9);
            Assert.IsTrue(temp.Seconds == 20);


        }

        #endregion

        #region TimePeriod
        [TestMethod]
        public void TimePeriod_Konstruktor_ZDwochStrukturTime_OK()
        {
            //act
            Time odcinekCzasu1 = new Time(1, 2, 3);
            Time odcinekCzasu2 = new Time(2, 3, 4);
            Time odcinekCzasu3 = new Time(22, 1, 1);
            Time odcinekCzasu4 = new Time(0, 11, 11);
            TimePeriod temp;

            temp = new TimePeriod(odcinekCzasu1, odcinekCzasu2);

            //assert
            Assert.IsTrue(temp.Hours == 1);
            Assert.IsTrue(temp.Minutes == 1);
            Assert.IsTrue(temp.Seconds == 1);
            Assert.IsTrue(temp.SecondsTotal == 3661);

            //act
            temp = new TimePeriod(odcinekCzasu3, odcinekCzasu4);

            //assert
            Assert.IsTrue(temp.Hours == 22);
            Assert.IsTrue(temp.Minutes == 10);
            Assert.IsTrue(temp.Seconds == 10);
            Assert.IsTrue(temp.SecondsTotal == 79810);

        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)2, (byte)3, (byte)1, (byte)2, (byte)3, (long)3723)]
        [DataRow((byte)2, (byte)1, (byte)15, (byte)2, (byte)1, (byte)15, (long)7275)]
        public void TimePeriod_Konstruktor_Trojargumentowy_OK(
            byte godzina, byte minuta, byte sekunda,
            byte expectedGodzina, byte expectedMinuta, byte expectedSekunda, long expectedSecondsTotal)
        {
            //act
            TimePeriod czas = new TimePeriod(godzina, minuta, sekunda);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
            Assert.AreEqual(expectedSecondsTotal, czas.SecondsTotal);
        }


        [DataTestMethod]
        [DataRow((byte)1, (byte)2, (byte)1, (byte)2, (byte)0, (long)3720)]
        [DataRow((byte)2, (byte)1, (byte)2, (byte)1, (byte)0, (long)7260)]
        public void TimePeriod_Konstruktor_Dwuargumentowy_OK(
           byte godzina, byte minuta,
           byte expectedGodzina, byte expectedMinuta, byte expectedSekunda, long expectedSecondsTotal)
        {
            //act
            TimePeriod czas = new TimePeriod(godzina, minuta);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
            Assert.AreEqual(expectedSecondsTotal, czas.SecondsTotal);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)1, (byte)0, (byte)0, (long)3600)]
        [DataRow((byte)2, (byte)2, (byte)0, (byte)0, (long)7200)]
        public void TimePeriod_Konstruktor_Jednoargumentowy_OK(
           byte godzina, byte expectedGodzina,
           byte expectedMinuta, byte expectedSekunda, long expectedSecondsTotal)
        {
            //act
            TimePeriod czas = new TimePeriod(godzina);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
            Assert.AreEqual(expectedSecondsTotal, czas.SecondsTotal);
        }

        [DataTestMethod]
        [DataRow("20:10:5", (byte)20, (byte)10, (byte)5, (long)72605)]
        [DataRow("          20:10:15        ", (byte)20, (byte)10, (byte)15, (long)72615)]
        public void TimePeriod_Konstruktor_string_OK(
            string godzina, byte expectedGodzina, byte expectedMinuta, byte expectedSekunda, long expectedTotalSeconds)
        {
            //act
            TimePeriod czas = new TimePeriod(godzina);

            //assert
            Assert.AreEqual(expectedGodzina, czas.Hours);
            Assert.AreEqual(expectedMinuta, czas.Minutes);
            Assert.AreEqual(expectedSekunda, czas.Seconds);
            Assert.AreEqual(expectedTotalSeconds, czas.SecondsTotal);
        }
        
        [TestMethod]
        public void TimePeriod_Plus_OK()
        {
            TimePeriod odcinek1 = new TimePeriod(10, 10, 10);
            TimePeriod odcinek2 = new TimePeriod(20, 20, 20);
            TimePeriod odcinek3 = new TimePeriod(70, 20, 20);
            TimePeriod temp;

            temp = odcinek1.Plus(odcinek2);

            Assert.IsTrue(temp.Hours == 30);
            Assert.IsTrue(temp.Minutes == 30);
            Assert.IsTrue(temp.Seconds == 30);
            Assert.IsTrue(temp.SecondsTotal == 109830);

            temp = odcinek2.Plus(odcinek3);

            Assert.IsTrue(temp.Hours == 90);
            Assert.IsTrue(temp.Minutes == 40);
            Assert.IsTrue(temp.Seconds == 40);
            Assert.IsTrue(temp.SecondsTotal == 326440);
        }

        [TestMethod]
        public void TimePeriod_CompareTo_OK()
        {
            TimePeriod czas1 = new TimePeriod(20, 20, 20);
            TimePeriod czas2 = new TimePeriod(20, 20, 21);
            TimePeriod czas3 = new TimePeriod(20, 21, 21);
            TimePeriod czas4 = new TimePeriod(21, 21, 21);
            TimePeriod czas5 = new TimePeriod(21, 21, 21);

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
        public void TimePeriod_Equals_OK()
        {
            TimePeriod czas1 = new TimePeriod(100, 2, 3);
            TimePeriod czas2 = new TimePeriod(100, 2, 3);
            TimePeriod czas3 = new TimePeriod(1, 3, 3);
            TimePeriod czas4 = new TimePeriod(2, 3, 3);
            TimePeriod czas5 = new TimePeriod(2, 3, 4);
            Assert.AreEqual(czas1, czas2);
            Assert.AreNotEqual(czas2, czas3);
            Assert.AreNotEqual(czas3, czas4);
            Assert.AreNotEqual(czas4, czas5);
        }

        #endregion
    }
}