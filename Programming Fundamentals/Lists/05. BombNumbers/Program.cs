using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void PrintFinalSum(List<int> numbers, int bomb, int power)
        {
            for (int a = 0; a < numbers.Count; a++)
            {
                if (numbers[a] == bomb)
                {

                    int eliminate;

                    if (a - power < 0)
                    {
                        eliminate = 0;
                    }
                    else
                    {
                        eliminate = a - power;
                    }

                    int range = 0;

                    while (eliminate < numbers.Count && range < (2 * power) + 1)
                    {
                        numbers.RemoveAt(eliminate);
                        range++;
                    }

                    a = 0;
                }
            }

            int sum = 0;

            for (int b = 0; b < numbers.Count; b++)
            {
                sum += numbers[b];
            }

            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombNumber = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            PrintFinalSum(sequence, bombNumber[0], bombNumber[1]);
        }
    }
}