using LeetCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Sort
{
    public class SortQuestions
    {
        public static void BubbleSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);

            BubbleSort(array);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        public static void SelectionSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);

            SelectionSort(array);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        public static void InsertionSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);

            InsertionSort(array);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        public static void QuickSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        public static void HeapSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);
            Console.WriteLine(ArrayHelper.PrintArray(array));

            HeapSort(array);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        public static void MergeSortRun()
        {
            int[] array = ArrayHelper.GenerateArray(20, 100, false);

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine(ArrayHelper.PrintArray(array));
        }

        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j - 1] >= array[j])
                    {
                        CommonHelper.SwapArray(array, j - 1, j);
                    }
                }
            }
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int smallestIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }

                CommonHelper.SwapArray(array, i, smallestIndex);
            }
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int current = array[j];

                while (j > 0 && current < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = current;
            }
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }

        private static int Partition(int[] array, int left, int right)
        {
            Random ran = new Random();
            var ranIndex = ran.Next(left, right);
            CommonHelper.SwapArray(array, left, ranIndex);

            int pivotValue = array[left];
            int pivotStart = left;

            while (left < right)
            {
                //Find first >= pivotValue and first <= pivotValue, swap them then fill in pivotValue at the last swap point
                while (left < right && array[right] >= pivotValue)
                {
                    right--;
                }

                while (left < right && array[left] <= pivotValue)
                {
                    left++;
                }

                CommonHelper.SwapArray(array, left, right);
            }

            CommonHelper.SwapArray(array, pivotStart, left);
            return left;
        }

        private static void HeapSort(int[] array)
        {
            //generate MaxHeap
            for (int i = array.Length / 2; i >= 0; i--)
            {
                AdjustHeap(array, i, array.Length - 1);
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                CommonHelper.SwapArray(array, 0, i);
                AdjustHeap(array, 0, i - 1);
            }
        }

        private static void AdjustHeap(int[] array, int start, int end)
        {
            int temp = array[start];

            //left child index 2n+1, right child index 2n+2
            for (int i = 2 * start + 1; i <= end; i *= 2)
            {
                //finding the largest child
                if (i + 1 <= end && array[i] < array[i + 1])
                {
                    i++;
                }

                //if current >= any of its children then maintain the same structure
                if (temp >= array[i])
                {
                    break;
                }

                array[start] = array[i];
                start = i;
            }

            array[start] = temp;
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;

            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);
            MergeArray(array, left, mid, right);
        }

        private static void MergeArray(int[] array, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];

            int l = left;
            int r = mid + 1;
            int k = 0;

            while (l <= mid && r <= right)
            {
                if (array[l] <= array[r])
                {
                    temp[k++] = array[l++];
                }
                else
                {
                    temp[k++] = array[r++];
                }
            }

            while (l <= mid)
            {
                temp[k++] = array[l++];
            }

            while (r <= right)
            {
                temp[k++] = array[r++];
            }

            for (int p = 0; p < temp.Length; p++)
            {
                array[left + p] = temp[p];
            }
        }
    }
}
