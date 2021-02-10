using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(nums);

            int s = NSX[1];
            for (int i = 0; i < s; i++)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("0");
                    break;
                }
                queue.Dequeue();
            }

            int x = NSX[2];
            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(x) && queue.Count != 0)
            {
                Console.WriteLine(queue.Min());
            }

            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
