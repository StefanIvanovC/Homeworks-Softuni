using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double biggestKeg = 0;
            string bestModel = "";
            for (int i = 0; i < count; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (biggestKeg < volume)
                {

                    biggestKeg = volume;
                    bestModel = model;
                }

            }

            Console.WriteLine(bestModel);
        }
    }
}