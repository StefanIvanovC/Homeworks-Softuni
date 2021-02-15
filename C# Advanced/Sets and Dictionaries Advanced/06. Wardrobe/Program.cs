using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var orderArr = Console.ReadLine().Trim().Split(" -> ");
                string color = orderArr[0];
                var clothesArr = orderArr[1].Trim().Split(",");

                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothesArr)
                {
                    if (!dict[color].ContainsKey(cloth))
                    {
                        dict[color].Add(cloth, 0);
                    }

                    dict[color][cloth]++;
                }
            }

            var searchedClothArr = Console.ReadLine().Trim().Split();
            string searchedColor = searchedClothArr[0];
            string searchedCloth = searchedClothArr[1];

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var kvp1 in kvp.Value)
                {
                    if (kvp1.Key == searchedCloth && kvp.Key == searchedColor)
                    {
                        Console.WriteLine($"* {kvp1.Key} - {kvp1.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp1.Key} - {kvp1.Value}");
                    }
                }
            }
        }
    }
}