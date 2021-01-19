using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] nums1 = new string[n];
            string[] nums2 = new string[n];

            for (int i = 0; i < n; i++)
            {
                var read = Console.ReadLine().Split();
                if (i % 2 == 0)
                {
                    nums1[i] = read[0];
                    nums2[i] = read[1];
                }
                else
                {
                    nums1[i] = read[1];
                    nums2[i] = read[0];
                }
            }

            Console.WriteLine(string.Join(" ", nums1));
            Console.WriteLine(string.Join(" ", nums2));
        }
    }
}