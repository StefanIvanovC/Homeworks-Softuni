using System;
using System.Collections.Generic;

namespace AssociativeArreys
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var curr = input[i];
                if (curr == ' ')
                {
                    continue;
                }
                if (!dict.ContainsKey(curr))
                {
                    dict[curr] = 0;
                }

                dict[curr]++;

            }

            foreach (var item in dict)
            {
                Console.WriteLine(string.Join(" ", $"{item.Key} -> {item.Value}"));
            }
        }
    }
}