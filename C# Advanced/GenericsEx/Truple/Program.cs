using System;

namespace Tuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split();
            string fullName = line1[0] + " " + line1[1];
            string address = line1[2];
            string town = line1[3];

            Tuple<string, string, string> first =
                new Tuple<string, string, string>(fullName, address, town);

            string[] line2 = Console.ReadLine().Split();
            string name = line2[0];
            int beer = int.Parse(line2[1]);
            bool drunk = false;
            if (line2[2] == "drunk") { drunk = true; }
            Tuple<string, int, bool> second =
                new Tuple<string, int, bool>(name, beer, drunk);

            string[] line3 = Console.ReadLine().Split();
            string secondName = line3[0];
            double doubleNumber = double.Parse(line3[1]);
            string bankName = line3[2];
            Tuple<string, double, string> third =
                new Tuple<string, double, string>
                (secondName, doubleNumber, bankName);

            Console.WriteLine($"{first.Item1} -> {first.Item2} -> {first.Item3}");
            Console.WriteLine($"{second.Item1} -> {second.Item2} -> {second.Item3}");
            Console.WriteLine($"{third.Item1} -> {third.Item2} -> {third.Item3}");
          

        }
    }
}