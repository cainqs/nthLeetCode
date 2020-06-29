using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Helper
{
    public class ArrayHelper
    {
        public static int[] GenerateArray(int count, int max, bool ordered)
        {
            Random ran = new Random();
            int[] ret = new int[count];

            for (int i = 0; i < count; i++)
            {
                ret[i] = ran.Next(max + 1);
            }

            if (ordered)
            {
                Array.Sort(ret);
            }

            return ret;
        }

        public static string PrintArray(int[] array)
        {
            string ret = string.Join(" -> ", array);

            return ret;
        }
    }
}
