using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int numbersOfRotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfRotation; i++)
            {
                var temp = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];

                }
                arr[arr.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}