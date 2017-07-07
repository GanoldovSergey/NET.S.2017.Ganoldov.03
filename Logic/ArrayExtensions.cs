using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ArrayExtensions
    {
        #region Insertion
        /// <summary>
        /// Inserts bits from positions i and j second number to first number
        /// </summary>
        /// <param name="first">The number that have to be inserted</param>
        /// <param name="second">The number some bites of wich have to be inserted into first</param>
        /// <param name="i">first index of bit</param>
        /// <param name="j">last index of bit</param>
        public static int? Insertion(int first, int second, int i, int j)
        {
            CheckIndexes(i, j);
            int mask1 = (second << j) & (int.MaxValue >> 30 - i);
            int mask2 = ~((int.MaxValue << j) & (int.MaxValue >> 30 - i));

            return (first & mask2) | mask1;
        }

        private static void CheckIndexes(int i, int j)
        {
            if (i < j || i > 32)
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region FindIndex
        ///<summary>
        ///Finds the first element in array, 
        ///for which the sum of right subarray equals
        ///the sum of left subarray
        ///</summary>
        ///<param name="arr">
        ///Integer array
        /// </param>
        /// <returns>
        ///Index of the first element in array, 
        ///for which the sum of right subarray equals
        ///the sum of left subarray
        /// </returns>
        public static int FindIndex(int[] arr)
        {
            CheckArray(arr);
            int rightSum = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                rightSum += arr[i];
            }

            int leftSum = 0;
            int index = 0;

            while (leftSum < rightSum)
            {
                index++;
                leftSum += arr[index - 1];
                rightSum -= arr[index];
            }

            if (leftSum == rightSum) return index;
            return -1;
        }

        private static void CheckArray(int[] a)
        {
            if (a == null) throw new ArgumentNullException();
            if (a.Length == 0) throw new ArgumentException();
            if (a.Length > 1000) throw new ArgumentException();
        }
        #endregion

        #region Sort
        /// <summary>
        /// Quick sort algorithm
        /// </summary>
        /// <param name="arr">The array to be sorted</param>
        public static void QuickSort(int[] arr)
        {
            CheckInputArray(arr);
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (left < j)
                QuickSort(arr, left, j);
            if (i < right)
                QuickSort(arr, i, right);
        }

        /// <summary>
        /// Merge sort algorithm
        /// </summary>
        /// <param name="arr">The array to be sorted</param>
        public static void MergeSort(int[] arr)
        {
            CheckInputArray(arr);
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left / 2) + (right / 2);

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }
        private static void Merge(int[] array, int left, int middle, int right)
        {
            int[] helper = new int[array.Length];

            for (int i = left; i <= right; i++)
            {
                helper[i] = array[i];
            }

            int helperLeft = left,
                helperRight = middle + 1,
                current = left;

            while (helperLeft <= middle && helperRight <= right)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            if (helperLeft > middle)
            {
                for (; helperRight <= right; helperRight++, current++)
                {
                    array[current] = helper[helperRight];
                }
            }
            else
            {
                for (; helperLeft <= middle; helperLeft++, current++)
                {
                    array[current] = helper[helperLeft];
                }
            }
        }

        private static void CheckInputArray(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region NextBiggerNumber
        ///<summary>
        ///Gets a positive integer number and returns the Next Bigger Number consisting from the same didgits
        /// </summary>
        /// <param name="number">
        /// Positive number
        /// </param>
        /// <returns>
        /// Next Bigger Number consisting from the same didgits.
        /// If not exist returns -1.
        /// </returns>
        public static int NextBiggerNumber(int number,out long time)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            CheckNumber(number);
            int[] arr = GetArrayFromNumber(number);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    for (int j = 0; j <= i - 1; j++)
                    {
                        if (arr[j] <= arr[i - 1] && arr[j] > arr[i])
                        {
                            Swap(ref arr[i], ref arr[j]);
                            Sort(arr, 0, i - 1);
                            time = t.ElapsedMilliseconds;
                            return FormNumberFromArray(arr);
                        }
                    }
                }
            }
            time = t.ElapsedMilliseconds;
            return -1;
        }

        private static void CheckNumber(int a)
        {
            if (a <= 0)
            {
                throw new ArgumentException();
            }
        }

        private static int FormNumberFromArray(int[] arr)
        {
            int res = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                res = res * 10 + arr[i];
            }
            return res;
        }
        private static void Sort(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] > pivot)
                    i++;
                while (arr[j] < pivot)
                    j--;
                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (left < j)
                Sort(arr, left, j);
            if (i < right)
                Sort(arr, i, right);
        }
        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        private static int[] GetArrayFromNumber(int a)
        {
            int n = GetArrayFromNumberLength(a);
            int[] arr = new int[n];
            for (int i = 0; a > 0; i++)
            {
                arr[i] = a % 10;
                a /= 10;
            }
            return arr;
        }
        private static int GetArrayFromNumberLength(int a)
        {
            int n = 0;
            while (a != 0)
            {
                a /= 10;
                n++;
            }
            return n;
        }
        #endregion
    }
}