using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {

            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age}
            //{tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] infoInput = Console.ReadLine().Split();

                string model = infoInput[0];

                int engineSpeed = int.Parse(infoInput[1]);

                int enginePower = int.Parse(infoInput[2]);


                int cargoWeight = int.Parse(infoInput[3]);
                string cargoType = infoInput[4];

                double tire1Pressure = double.Parse(infoInput[5]);
                int tire1Age = int.Parse(infoInput[6]);

                double tire2Pressure = double.Parse(infoInput[7]);
                int tire2Age = int.Parse(infoInput[8]);

                double tire3Pressure = double.Parse(infoInput[9]);
                int tire3Age = int.Parse(infoInput[10]);

                double tire4Pressure = double.Parse(infoInput[11]);
                int tire4Age = int.Parse(infoInput[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                int counter = 0;

                for (int j = 5; j < infoInput.Length; j += 2)
                {
                    double tirePressure = double.Parse(infoInput[j]);
                    int tireAge = int.Parse(infoInput[j + 1]);

                    Tire tire = new Tire(tireAge, tirePressure);
                    tires[counter++] = tire;
                }




                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
                
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragileType = cars.Where(x => x.Cargo.Type == "fragile" &&
                x.Tires.Any(p => p.Pressure < 1)).ToList();

                foreach (var car in fragileType)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                var flamable = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power >= 250).ToList();

                foreach (var car in flamable)
                {
                    Console.WriteLine(car.Model);

                }

            }
        }
    }
}
