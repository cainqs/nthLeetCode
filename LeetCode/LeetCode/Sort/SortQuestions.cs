using LeetCode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
