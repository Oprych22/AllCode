using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class RotateLeft
    {
        static int[] rotLeft(int[] a, int d)
        {

            int length = a.Length;

            int[] b = new int[length];

            d = d % length;

            for (int i = 0; i < length; i++)
            {
                var newIndex = i + d;
                if (newIndex >= length)
                    newIndex %= length;
                b[i] = a[newIndex];
            }
            return b;

        }

        //static void Main(string[] args)
        //{


        //    int[] a = new int [] { 1, 2, 3, 4, 5 };

        //   int d = 7 ;
        //    int[] result = rotLeft(a, d);

        //}
    }
}
