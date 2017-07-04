using System;
using NUnit.Framework;

namespace Logic.NUnit.Test
{
    public class UnitTest1
    {
        #region FindIndex

        [TestCase(new[] { 1, 2, 3, 4, 3, 2, 1 }, ExpectedResult = 3)]
        [TestCase(new[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 0, 10, 5, 4 }, ExpectedResult = -1)]
        public int FindIndex_ValidInputArray_Index(int[] arr)
        {
            return IntAlg.FindIndex(arr);
        }

        [TestCase(new int[] { })]
        public void FindIndex_InvalidInputArray_ThrowsArgumentException(int[] arr)
        {
            Assert.Throws<ArgumentException>(() => IntAlg.FindIndex(arr));
        }

        [TestCase(null)]
        public void FindIndex_NullInputArray_ThrowsArgumentNullException(int[] array)
        {
            Assert.Throws<NullReferenceException>(() => IntAlg.FindIndex(array));
        }

        #endregion

        #region NextBiggerNumber
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public static int NextBiggerNumber_ValidInputNumber_NextBiggerNumber(int n)
        {
            return IntAlg.NextBiggerNumber(n);
        }

        [TestCase(-12)]
        [TestCase(0)]
        public static void NextBiggerNumber_InValidInputNumber_ThrowsArgumentException(int n)
        {
            Assert.Throws<ArgumentException>(() => IntAlg.NextBiggerNumber(n));
        }

        #endregion

    }
}
