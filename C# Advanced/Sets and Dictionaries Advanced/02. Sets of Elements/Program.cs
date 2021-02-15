using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = input[0];
            int second = input[1];

            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();

            for (int i = 0; i < first; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                firstNumbers.Add(nums);
            }
            for (int i = 0; i < second; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                secondNumbers.Add(nums);
            }

            var intersectNumbers = firstNumbers.Intersect(secondNumbers);
            Console.WriteLine(string.Join((" "), intersectNumbers));

        }
    }
}