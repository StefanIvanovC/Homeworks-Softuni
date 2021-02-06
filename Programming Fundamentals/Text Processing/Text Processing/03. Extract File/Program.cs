using System;
using System.Linq;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string[] allPaths = path.Split("\\", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string pathAndEnd = allPaths[3];
            string[] clearPath = pathAndEnd.Split(".", StringSplitOptions.RemoveEmptyEntries);
            string first = clearPath[0];
            string second = clearPath.Last();

            Console.WriteLine($"File name: {first}");
            Console.WriteLine($"File extension: {second}");
        }
    }
}