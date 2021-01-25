using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = char.Parse(Console.ReadLine());
            var secondInput = char.Parse(Console.ReadLine());

            int start = Math.Min(firstInput, secondInput);
            int end = Math.Max(firstInput, secondInput);

            for (int i = start + 1; i < end; i++)
            {
                char symbol = (char)i;

                Console.Write(symbol + " ");
            }
        }
    }
}
