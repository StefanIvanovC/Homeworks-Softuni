using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            var stop = "";
            while (stop != "stop")
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                var quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict[input] = quantity;
                }
                else
                {
                    dict[input] += quantity;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine(string.Join(" ", $"{item.Key} -> {item.Value}"));
            }
        }
    }
}