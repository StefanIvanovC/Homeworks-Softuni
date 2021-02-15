using System;
using System.Collections.Generic;

namespace _01.UniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string names = Console.ReadLine();
                set.Add(names);

            }

            foreach (string name in set)
            {
                Console.WriteLine(string.Join(" ", name));
            }
        }
    }
}