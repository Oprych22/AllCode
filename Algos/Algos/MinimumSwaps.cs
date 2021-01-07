using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class MinimumSwaps
    {

        public static int  MinSwaps(int[] a)
        {
            int swap = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i + 1 != a[i])
                {
                    int t = i;
                    while (a[t] != i + 1)
                    {
                        t++;
                    }
                    int temp = a[t];
                    a[t] = a[i];
                    a[i] = temp;
                    swap++;
                }
            }
            return swap;
        }

        //static void Main(string[] args)
        //{
        //    int res = MinSwaps(new int[] { 2, 3, 4, 1, 5 });

        //}
    }
}
