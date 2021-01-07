using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class Fibonnaci
    {
        public static int Fib(int n)
        {
            return n > 1 ?  Fib(n - 1) + Fib(n - 2) :  n;
        }
        public static void Main()
        {
            int sq = Fib(3);
        }
    }
}
