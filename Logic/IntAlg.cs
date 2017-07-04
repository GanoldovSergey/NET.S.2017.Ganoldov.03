using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class IntAlg
    {
        #region Insertion
        public static int? Insertion(int first, int second, int i, int j)
        {
            CheckIndexes(i,j);
            int mask1 = second << j;
            int mask2 = int.MaxValue >> 30 - i;
            int totalMask = mask1 & mask2;
            return first & totalMask;
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
            if (a == null) throw new NullReferenceException();
            if (a.Length == 0) throw new ArgumentException();
            if (a.Length > 1000) throw new ArgumentException();
        }
        #endregion

        #region Sort
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
                throw new NullReferenceException();
            }
            if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region NextBiggerNumber
        public static int NextBiggerNumber(int a)
        {
            CheckNumber(a);
            int[] arr = GetArrayFromNumber(a);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i-1])
                {
                    Swap(ref arr[i], ref arr[i-1]);
                    Sort(arr,0, i-1);
                    return FormNumberFromArray(arr);
                }
            }
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
            for (int i = arr.Length-1; i >=0; i--)
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
