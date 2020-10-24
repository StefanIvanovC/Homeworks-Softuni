using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsEx
{
     public class Program
    {
         public static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();

            string name = $"{tokens[0]} {tokens[1]}";
            string location = tokens[2];

            Tuple<string, string> tuple = new Tuple<string, string>(name,location);


            string[] secondTokens = Console.ReadLine().Split();

            string nameSecond = secondTokens[0];
            int beer = int.Parse(secondTokens[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(nameSecond, beer);

            string[] thirdTokens = Console.ReadLine().Split();

            int firstThird = int.Parse(thirdTokens[0]);
            double secondThird = double.Parse(thirdTokens[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(firstThird, secondThird);

            Console.WriteLine($"{tuple}");
            Console.WriteLine($"{secondTuple}");
            Console.WriteLine($"{thirdTuple}");



        }

    }
}
