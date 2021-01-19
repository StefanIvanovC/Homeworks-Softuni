using System;

namespace second
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();
            string result = "";
            foreach (var word in arr1)
            {
                foreach (var word2 in arr2)
                {
                    if (word == word2)
                    {
                        result += word + " ";
                    }

                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}