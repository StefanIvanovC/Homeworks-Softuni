using System;

namespace ConsoleApp45
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstN = long.Parse(Console.ReadLine());
            long secondN = long.Parse(Console.ReadLine());
            long thirdN = long.Parse(Console.ReadLine());
            long fourthN = long.Parse(Console.ReadLine());

            long sum = firstN + secondN;
            long devided = sum / thirdN;
            long multiply = devided * fourthN;

            Console.WriteLine(multiply);
        }
    }
}
