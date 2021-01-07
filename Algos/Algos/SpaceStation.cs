using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class SpaceStation
    {
        static int flatlandSpaceStations(int n, int[] c)
        {
            Array.Sort(c);
            

            int maxPossible = 0;

            for (int i = 0; i< c.Length-1; i++)
            {
                int possMax = (c[i+1 ] - c[i]) / 2;
                if (possMax > maxPossible)
                {
                    maxPossible = possMax;
                }
            }

            if (n - c[c.Length-1] > maxPossible)
            {
                maxPossible = n - c[c.Length - 1] - 1;
            }

            if (c[0] > maxPossible)
            {
                maxPossible = c[0];
            }

            return maxPossible;
        }

        //public static void Main()
        //{

        //    int m = 2;

        //    int[] n = new int[] { 0, 4 };

        //    int max = flatlandSpaceStations(m, n);



        //     m = 20;

        //     n = new int[] { 13, 1, 11, 10, 6 };

        //    max = flatlandSpaceStations(m, n);
        //}
    }
}
