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
            return ArrayExtensions.FindIndex(arr);
        }

        [TestCase(new int[] { })]
        public void FindIndex_InvalidInputArray_ThrowsArgumentException(int[] arr)
        {
            Assert.Throws<ArgumentException>(() => ArrayExtensions.FindIndex(arr));
        }

        [TestCase(null)]
        public void FindIndex_NullInputArray_ThrowsArgumentNullException(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.FindIndex(array));
        }

        #endregion

        #region Sort
        [TestCase(new[] { 1, 2, 3, 4, 3, 2, 1 }, ExpectedResult = new[] { 1, 1, 2, 2, 3, 3, 4 })]
        [TestCase(new[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = new[] { -51, 1, 1, 1, 50, 100 })]
        [TestCase(new[] { 0, 10, 5, 4 }, ExpectedResult = new[] { 0, 4, 5, 10 })]
        public int[] QuickSort_ValidInputArray_SortedArray(int[] arr)
        {
            ArrayExtensions.QuickSort(arr);
            return arr;
        }

        [TestCase(new int[] { })]
        public void QuickSort_EmptyInputArray_ThrowsArgumentException(int[] arr)
        {
            Assert.Throws<ArgumentException>(() => ArrayExtensions.QuickSort(arr));
        }

        [TestCase(null)]
        public void QuickSort_NullInputArray_ThrowsArgumentNullException(int[] arr)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.QuickSort(arr));
        }

        [TestCase(new[] { 1, 2, 3, 4, 3, 2, 1 }, ExpectedResult = new[] { 1, 1, 2, 2, 3, 3, 4 })]
        [TestCase(new[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = new[] { -51, 1, 1, 1, 50, 100 })]
        [TestCase(new[] { 0, 10, 5, 4 }, ExpectedResult = new[] { 0, 4, 5, 10 })]
        public int[] MergeSort_ValidInputArray_SortedArray(int[] arr)
        {
            ArrayExtensions.MergeSort(arr);
            return arr;
        }

        [TestCase(new int[] { })]
        public void MergeSort_EmptyInputArray_ThrowsArgumentException(int[] arr)
        {
            Assert.Throws<ArgumentException>(() => ArrayExtensions.MergeSort(arr));
        }

        [TestCase(null)]
        public void MergeSort_NullInputArray_ThrowsArgumentNullException(int[] arr)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.MergeSort(arr));
        }
        #endregion

        #region NextBiggerNumber
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1204321, ExpectedResult = 1210234)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public static int NextBiggerNumber_ValidInputNumber_NextBiggerNumber(int n)
        {
            long time;
            return ArrayExtensions.NextBiggerNumber(n,out time);
        }

        [TestCase(-12)]
        [TestCase(0)]
        public static void NextBiggerNumber_InValidInputNumber_ThrowsArgumentException(int n)
        {
            long time;
            Assert.Throws<ArgumentException>(() => ArrayExtensions.NextBiggerNumber(n,out time));
        }

        #endregion

    }
}
