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
            var jsonSles = File.ReadAllText("../../../Datasets/sales.json");


            var result = GetOrderedCustomers(context);

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get first 10 sales with information about the car, customer and price of
            //the sale with and without discount.Export the list of sales to JSON in the format provided below.

            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount}",
                    price = $"{s.Car.PartCars.Select(p => p.Part.Price).Sum()}",
                    priceWithDiscount = $"{((s.Car.PartCars.Select(p => p.Part.Price).Sum()) * (1.00m - (s.Discount / 100))):f2}"
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context) 
        {
            //Get all customers that have bought at least 1 car and get their names, bought cars count and
            //total spent money on cars
            //.Order the result list by total spent money descending then by total bought cars again in descending order.
            
            var customers = context.Customers
                .Where(x => x.Sales.Select(car => car.Car).Count() >= 1)
                .Select(c => new 
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Select(car => car.Car).Count(),
                    spentMoney = c.Sales
                        .Select(s => s.Car.PartCars
                                    .Select(m => m.Part.Price)
                                    .Sum())
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }
      
        public static string GetCarsWithTheirListOfParts(CarDealerContext context) //Query 15. Export Cars with Their List of Parts
        {
            //    Get all cars along with their list of parts.
            //    For the car get only make, model and travelled distance and for the parts get only name and
            //    price(formatted to 2nd digit after the decimal point).
            //    Export the list of cars and their parts to JSON in the format provided below.

            var cars = context.Cars
               .Select(c => new
               {
                   car = new
                   {
                       Make = c.Make,
                       Model = c.Model,
                       TravelledDistance = c.TravelledDistance
                   },
                   parts = c.PartCars.Select(p => new
                   {
                       Name = p.Part.Name,
                       Price = $"{p.Part.Price:f2}"
                   })
                    .ToArray()
               })
               .ToArray();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context) 
        {
            //Get all suppliers that do not import parts from abroad. +
            //Get their id, name and the number of parts they can offer to supply. +
            //Export the list of suppliers to JSON in the format provided below.
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter != true)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return result;

        }

        public static string GetCarsFromMakeToyota(CarDealerContext context) 
        {
            //Get all cars from make Toyota and order them by model alphabetically and by travelled distance descending.
            //Export the list of cars to JSON in the format provided below.

            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            //Get all customers ordered by their birth date ascending.
            //If two customers are born on the same date first print those who are not young drivers
            //(e.g.print experienced drivers first)
            //Export the list of customers to JSON in the format provided below

            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);

            return result;

        }


        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<ImportSalesModel[]>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";

        }

        public static string ImportCustomers(CarDealerContext context, string inputJson) // Query 12. Import Sales
        {
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson).ToList();

            context.AddRange(customers);
            context.SaveChanges();

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