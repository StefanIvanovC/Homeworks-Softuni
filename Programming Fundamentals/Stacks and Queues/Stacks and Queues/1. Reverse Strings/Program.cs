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
            Stack<char> charact = new Stack<char>(Console.ReadLine());
            while (charact.Count > 0)
            {
                char dt = charact.Pop();
                Console.Write(dt);
            }
        }
    }
}