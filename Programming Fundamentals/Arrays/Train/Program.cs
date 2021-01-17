using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var wagonsNums = new int[input];
            var sum = 0;
            for (int i = 0; i < input; i++)
            {
                wagonsNums[i] = int.Parse(Console.ReadLine());
                sum += wagonsNums[i];
            }

            foreach (var item in wagonsNums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}