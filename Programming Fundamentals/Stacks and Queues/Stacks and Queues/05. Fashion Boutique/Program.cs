using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothValues = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToList();
            var capacity = int.Parse(Console.ReadLine());

            var racks = 0;
            var sum = 0;

            var box = new Stack<int>(clothValues);

            while (box.Count > 0)
            {
                var currentSize = sum + box.Peek();

                if (currentSize < capacity)
                {
                    sum += box.Pop();
                }
                else if (currentSize == capacity)
                {
                    racks++;
                    box.Pop();
                    sum = 0;
                }
                else
                {
                    racks++;
                    sum = box.Pop();
                }
            }

            if (sum > 0)
            {
                racks++;
            }

            Console.WriteLine(racks);
        }
    }
}
