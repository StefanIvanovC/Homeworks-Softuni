using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] auto = Console.ReadLine().Split();
                string model = auto[0];
                double fuelAmount = double.Parse(auto[1]);
                double fuelconsumption = double.Parse(auto[2]);

                Car car = new Car(model, fuelAmount, fuelconsumption);
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split();
                string model = data[1];
                int amount = int.Parse(data[2]);

                Car car = cars.FirstOrDefault(x => x.Model == model);

                car.Drive(amount);

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }

     
    }

}
