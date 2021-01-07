using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class SherlockAndSquares
    {
        static int squares(int a, int b)
        {
            int numSquares = 0;

            var sqrtLow = Math.Ceiling(Math.Sqrt(a));

            var sqrtHigh = Math.Floor(Math.Sqrt(b));

            for (var j = sqrtLow; j <= sqrtHigh; j++)
            {
                var square = j * j;

                if (square >= a && square <= b)
                    numSquares++;
            }
            Console.WriteLine(numSquares);
            return numSquares;
        }

        //public static void Main()
        //{
        //    int sq = squares(100, 1000);
        //}
    }
}
