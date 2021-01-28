using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];
                int element = int.Parse(tokens[1]);

                if (command == "Delete")
                {
                    listOfIntegers.RemoveAll(x => x == element);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    listOfIntegers.Insert(index, element);
                }
            }

            Console.WriteLine(string.Join(" ", listOfIntegers));
        }

    }
}