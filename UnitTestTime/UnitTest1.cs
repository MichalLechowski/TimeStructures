using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLibrary;

namespace UnitTestTime
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow((byte)1, (byte)2, (byte)3, (byte)1, (byte)2, (byte)3)]
        [DataRow((byte)5, (byte)10, (byte)15, (byte)5, (byte)10, (byte)15)]

        public void Konstructor_Trojargumentowy_BezModulo_OK(
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
        [DataRow((byte)25, (byte)61, (byte)65, (byte)1, (byte)1, (byte)5)]
        [DataRow((byte)30, (byte)70, (byte)80, (byte)6, (byte)10, (byte)20)]

        public void Konstructor_Trojargumentowy_Modulo_OK(
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
        public void Konstructor_Dwuargumentowy_OK(
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
        public void Konstructor_Jednoargumentowy_OK(
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

        [DataTestMethod]
        [DataRow("20:10:5", (byte)20, (byte)10, (byte)5)]
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

    }
}
