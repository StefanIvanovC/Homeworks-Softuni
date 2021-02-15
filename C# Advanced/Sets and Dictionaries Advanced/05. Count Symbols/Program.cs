using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> ocurrences = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                var charCurrent = text[i];
                if (ocurrences.Keys.Contains(charCurrent))
                {
                    ocurrences[charCurrent]++;
                    continue;
                }

                if (!ocurrences.Keys.Contains(charCurrent))
                {
                    ocurrences.Add(charCurrent, 0);
                    ocurrences[charCurrent]++;
                }
            }

            foreach (var character in ocurrences)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}