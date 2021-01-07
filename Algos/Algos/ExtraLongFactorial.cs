using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class ExtraLongFactorial
    {
        static void extraLongFactorials(int n)
        {
            System.Numerics.BigInteger fac = new System.Numerics.BigInteger();
            fac = 1;
            for (int i = 1; i < n + 1; i++)
            {
                fac *= i;
            }
            Console.Out.Write(fac);
        }

        //static void Main(string[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());

        //    extraLongFactorials(n);
        //}

    }
}
