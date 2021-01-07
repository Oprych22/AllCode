using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algos
{
    public static class RansomNote
    {
        static string checkMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int> wordsInNote = new Dictionary<string, int>();

            foreach (var word in note)
            { 
                if (wordsInNote.ContainsKey(word))
                {
                    wordsInNote[word]++;
                }
                else
                {
                    wordsInNote.Add(word, 1);
                }
            }

            foreach(var word in magazine)
            {
                if (wordsInNote.ContainsKey(word))
                {
                    wordsInNote[word]--;
                    if (wordsInNote[word] == 0)
                    {
                        wordsInNote.Remove(word);
                    }
                }
            }

            if (wordsInNote.Count == 0)
                return "yes";
            else
                return "no";

        }
        //static void Main(string[] args)
        //{
        //    string[] mn = Console.ReadLine().Split(' ');

        //    int m = Convert.ToInt32(mn[0]);

        //    int n = Convert.ToInt32(mn[1]);

        //    string[] magazine = Console.ReadLine().Split(' ');

        //    string[] note = Console.ReadLine().Split(' ');

        //    checkMagazine(magazine, note);
        //}
    }
}
