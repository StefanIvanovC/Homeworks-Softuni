using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] callNumbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] webUrls = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartP = new Smartphone();
            StationaryPhone stationP = new StationaryPhone();

            for (int i = 0; i < callNumbers.Length; i++)
            {
                if (callNumbers[i].Length == 10)
                {
                    Console.WriteLine(smartP.Call(callNumbers[i]));
                }
                if (callNumbers[i].Length == 7)
                {
                    Console.WriteLine(stationP.Call(callNumbers[i]));
                }
                if (callNumbers[i].Length != 7 && callNumbers[i].Length != 10)
                {
                    Console.WriteLine("Invalid number!");
                }
                

            }

            for (int i = 0; i < webUrls.Length; i++)
            {
                Console.WriteLine(smartP.Browse(webUrls[i]));
            }

        }
    }
}
