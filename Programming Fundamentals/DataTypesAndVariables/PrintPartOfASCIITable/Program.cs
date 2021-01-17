using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            string fin = "";

            for (int i = n; i <= f; i++)
            {
                fin += (char)i + " ";
            }

            Console.WriteLine(fin);
        }
    }
}