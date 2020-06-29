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

        private static void BubbleSort(int[] array, bool asc = true)
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
    }
}
