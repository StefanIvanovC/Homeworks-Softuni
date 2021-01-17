using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPersons = int.Parse(Console.ReadLine());
            int capasity = int.Parse(Console.ReadLine());

            if (nPersons % capasity != 0)
            {
                Console.WriteLine((nPersons / capasity) + 1);
            }
            else if (nPersons / capasity == 0)
            {
                Console.WriteLine((nPersons / capasity));
            }
        }
    }
}