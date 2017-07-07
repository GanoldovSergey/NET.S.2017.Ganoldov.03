using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.MSUnitTests
{
    [TestClass]
    public class SpecailMethodsTests
    {
        [TestMethod]
        public void NextBiggerNumber_1234321_1241233()
        {
            long time;
            Assert.AreEqual(1241233, ArrayExtensions.NextBiggerNumber(1234321,out time));
        }

        [TestMethod]
        public void NextBiggerNumber_513_531()
        {
            long time;
            Assert.AreEqual(531, ArrayExtensions.NextBiggerNumber(513, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_12_21()
        {
            long time;
            Assert.AreEqual(21, ArrayExtensions.NextBiggerNumber(12, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_11109742_11120479()
        {
            long time;
            Assert.AreEqual(11120479, ArrayExtensions.NextBiggerNumber(11109742, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_111_minus1()
        {
            long time;
            Assert.AreEqual(-1, ArrayExtensions.NextBiggerNumber(111, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_10_minus1()
        {
            long time;
            Assert.AreEqual(-1, ArrayExtensions.NextBiggerNumber(10, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_minus324_ArgumentException()
        {
            long time;
            Assert.Throws<ArgumentException>(() => ArrayExtensions.NextBiggerNumber(-324, out time));
        }

        [TestMethod]
        public void NextBiggerNumber_IntMinValue_ArgumentException()
        {
            long time;
            Assert.Throws<ArgumentException>(() => ArrayExtensions.NextBiggerNumber(int.MinValue, out time));
        }

    }
}