using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int capacity = 255;

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int include = int.Parse(Console.ReadLine());

                if (sum + include > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += include;
                }
            }

            Console.WriteLine(sum);
        }
    }
}