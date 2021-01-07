using System;
using System.Collections.Generic;
using System.Text;

namespace Algos
{
    public static class AppendDelete
    {
        static string appendAndDelete(string s, string t, int k)
        {
            int startingMatch = 0;

            for (int i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                if (s[i] == t[i])
                {
                    startingMatch++; ; ;
                }
                else
                {
                    break;
                }
            }

            var minOps = (s.Length - startingMatch) + (t.Length - startingMatch);
            if (k < minOps)
            {
                return "No";
            }

            if (k == minOps || (k - minOps) % 2 == 0)
            {
                return "No";
            }

            if (s.Length + t.Length <= k)
            {
                return "Yes";
            }
            
            return "No";


        }

        //static void Main(string[] args)
        //{
        //    string s = "aaaaaaaaaa";

        //    string t = "aaaaa";

        //    int k = 7;

        //    appendAndDelete(s,t,k);
        //}
    }
}
