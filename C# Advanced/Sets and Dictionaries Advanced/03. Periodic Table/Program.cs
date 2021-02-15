using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> names = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var uniqueName = Console.ReadLine().Split();
                for (var j = 0; j < uniqueName.Length; j++)
                {
                    var element = uniqueName[j];
                    names.Add(element);
                }
            }
            foreach (var name in names)
            {
                Console.Write(String.Join(" ", name) + " ");
            }
        }
    }
}