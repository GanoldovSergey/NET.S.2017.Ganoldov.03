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
            Assert.AreEqual(1241233, ArrayExtensions.NextBiggerNumber(1234321));
        }

        [TestMethod]
        public void NextBiggerNumber_513_531()
        {
            Assert.AreEqual(531, ArrayExtensions.NextBiggerNumber(513));
        }

        [TestMethod]
        public void NextBiggerNumber_12_21()
        {
            Assert.AreEqual(21, ArrayExtensions.NextBiggerNumber(12));
        }

        [TestMethod]
        public void NextBiggerNumber_11109742_11120479()
        {
            Assert.AreEqual(11120479, ArrayExtensions.NextBiggerNumber(11109742));
        }

        [TestMethod]
        public void NextBiggerNumber_111_minus1()
        {
            Assert.AreEqual(-1, ArrayExtensions.NextBiggerNumber(111));
        }

        [TestMethod]
        public void NextBiggerNumber_10_minus1()
        {
            Assert.AreEqual(-1, ArrayExtensions.NextBiggerNumber(10));
        }

        [TestMethod]
        public void NextBiggerNumber_minus324_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtensions.NextBiggerNumber(-324));
        }

        [TestMethod]
        public void NextBiggerNumber_IntMinValue_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtensions.NextBiggerNumber(int.MinValue));
        }

    }
}