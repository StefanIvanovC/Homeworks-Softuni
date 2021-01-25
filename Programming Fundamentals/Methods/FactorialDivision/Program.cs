using System;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            var one = Factoriel(first);
            var two = Factoriel(second);

            var devided = one / two;

            Console.WriteLine($"{devided:f2}");
        }

        static double Factoriel(int a)
        {
            double factoriel = 1;

            for (int i = a; i > 0; i--)
            {
                factoriel *= i;

            }

            return factoriel;
        }
    }
}