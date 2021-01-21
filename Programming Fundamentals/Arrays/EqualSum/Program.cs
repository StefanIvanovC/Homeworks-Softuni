using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var founNum = false;

            for (int i = 0; i < input.Length; i++)
            {
                var leftSum = 0;
                var rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += input[j];
                }

                for (int k = i + 1; k < input.Length; k++)
                {
                    rightSum += input[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(Array.IndexOf(input, input[i]));
                    founNum = true;
                }
            }

            if (founNum == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}