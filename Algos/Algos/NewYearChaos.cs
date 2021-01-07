using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class NewYearChaos
    {
        static void minimumBribes(int[] q)
        {
            int bribes = 0;

            for (int i = q.Length - 1; i >= 0 ; i--)
            {
                int element = i + 1;
                if (q[i] != element)
                {
                    if (q[i - 1] == element)
                    {
                        q[i - 1] = q[i];
                        q[i] = element;
                        bribes++;
                    }
                    else if (q[i - 2] == element)
                    {
                        q[i - 2] = q[i - 1];
                        q[i - 1] = q[i];
                        q[i] = element;
                        bribes += 2;
                    }
                    else
                    {
                        Console.WriteLine("Too chaotic");
                        bribes = 0;
                        break;
                    }
                }
            }

            if (bribes > 0)
                Console.WriteLine(bribes);


        }

        //static void Main(string[] args)
        //{
        //     minimumBribes(new int[] { 2, 1, 5, 3, 4 });
        //}
    }
}
