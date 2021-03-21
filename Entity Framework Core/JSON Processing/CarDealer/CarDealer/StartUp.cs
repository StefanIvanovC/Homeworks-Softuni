using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var jsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var jsonParts = File.ReadAllText("../../../Datasets/parts.json");
            var jsonCars = File.ReadAllText("../../../Datasets/cars.json");
            var jsoncustomers = File.ReadAllText("../../../Datasets/customers.json");


            var result = ImportCustomers(context, jsoncustomers);

            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson) // Query 12. Import Sales
        {
            var customers = JsonConvert
                .DeserializeObject<IEnumerable<Customer>>(inputJson)
                .ToList();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson) // Query 10. Import Cars
        {
            var cars = JsonConvert
                .DeserializeObject<IEnumerable<ImportCarInputModel>>(inputJson);

            var listOfCars = new List<Car>(); 

            foreach (var car in cars)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson) // Query 9. Import Parts
        {
            var suppliersId = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var parts = JsonConvert
                .DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(s => suppliersId.Contains(s.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";

        } 

        public static string ImportSuppliers(CarDealerContext context, string inputJson) 
        {
            var suppliersDto = JsonConvert
                .DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.isImporter
            })
            .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        } // Query 8. Import Suppliers

        //private static void InitializeAutoMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile <ImportSupplierInputModel>();
        //});
        //    mapper = config.CreateMapper();
        //}
    }
}