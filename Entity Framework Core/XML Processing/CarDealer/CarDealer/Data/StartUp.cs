using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using XmlFacade;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var supplierXmltext = File.ReadAllText("./Datasets/suppliers.xml");
            var partsXmltext = File.ReadAllText("./Datasets/parts.xml");
            var carsXmltexl = File.ReadAllText(".//Datasets/cars.xml");
            var salesXmlText = File.ReadAllText(".//Datasets/cars.xml");
            var customersXmlText = File.ReadAllText(".//Datasets/customers.xml");

            //var result = ImportSales(context, salesXmlText);

            Console.WriteLine(GetCarsFromMakeBmw(context));

        }




        public static string GetCarsFromMakeBmw(CarDealerContext context) 
        {
            //Get all cars from make BMW and order them by model alphabetically and by travelled distance descending.

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarBMWOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravellerdDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravellerdDistance)
                .ToArray();

            var xmlConvertedCars = XmlConverter.Serialize(cars, "cars");

            return xmlConvertedCars;
        }

        public static string GetCarsWithDistance(CarDealerContext context)  // Query 14. Cars With Distance EXPORT
        {
            //Get all cars with distance more than 2,000,000. Order them by make, then by model alphabetically. Take top 10 records.

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var result = XmlConverter.Serialize(cars, "cars");

            return result;
        }


        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var root = "Customers";

            var customerDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);

            var customers = customerDto
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        } // Query 12. Import Customers


        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var root = "Sales";

            var saleDto = XmlConverter.Deserializer<SalesInputModel>(inputXml, root);

            //ToDO wHERE CARID IS NOT MISSING
            var carsId = context.Cars
                .Select(x => x.Id)
                .ToList();

            var sales = saleDto
                .Where(x => carsId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        } //Query 13. Import Sales

        public static string ImportCars(CarDealerContext context, string inputXml) 
        {
            var root = "Cars";

            var carDto = XmlConverter.Deserializer<CarInputModel>(inputXml, root);

            var allParts = context.Parts
                .Select(p => p.Id)
                .ToList();

            var cars = carDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                        .Distinct()
                        .Intersect(allParts)
                        .Select(pc => new PartCar
                        {
                            PartId = pc
                        })
                        .ToList()
                })
                .ToList();
            
            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        /// <summary>
        /// 10th Exercise - ImportParts from Xml to PartInputModel and deserialize it and add them in the DataBase
        /// </summary>
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var root = "Parts";

            var partsDto = XmlConverter.Deserializer<PartInputModel>(inputXml, root);

            //var serialise = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            //var textRead = new StringReader(inputXml);
            //var partsDto = serialise.Deserialize(textRead) as PartInputModel[];

            var suppId = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(x => suppId.Contains(x.SupplierId))
                .Select(p => new Part
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierId = p.SupplierId 
            })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }


        /// <summary>
        /// This method Import and Deserioalize the Suppliers from Xml file suppliers to SuplierInputModel to the Databese
        /// </summary>
        /// 9th Exercise
        public static string ImportSuppliers(CarDealerContext context, string inputXml) 
        {
            var root = "Suppliers";

            var suppliersDto = XmlConverter.Deserializer<SupplierInputModel>(inputXml, root);

            //var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            //var textRead = new StringReader(inputXml);
            //var suppliersDto = serializer.Deserialize(textRead) as SupplierInputModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter,
            })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            
            return $"Successfully imported {suppliers.Count}";
        }
    }
}