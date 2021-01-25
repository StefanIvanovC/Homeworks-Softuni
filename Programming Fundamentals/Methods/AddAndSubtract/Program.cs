using System;

namespace chacher
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());


            var fin = SubtractMethod(SumMethod(first, second), third);
            Console.WriteLine(fin);
        }

        static int SubtractMethod(int a, int b)
        {
            var subtract = a - b;
            return subtract;
        }

        static int SumMethod(int a, int b)
        {
            var sum = a + b;
            return sum;
        }
    }
}