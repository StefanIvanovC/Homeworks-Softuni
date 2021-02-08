using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> quie = new Queue<int>();

            while (quie.Count > 5)
            {
                quie.Enqueue(2);

            }

            foreach (var item in quie)
            {
                Console.WriteLine(quie.Peek());
            }
         }
    }
}