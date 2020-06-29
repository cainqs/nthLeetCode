using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Helper
{
    public class CommonHelper
    {
        public static void SwapArray(int[] array, int i, int j)
        {
            if (i >= 0 && i < array.Length && j >= 0 && j < array.Length)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
