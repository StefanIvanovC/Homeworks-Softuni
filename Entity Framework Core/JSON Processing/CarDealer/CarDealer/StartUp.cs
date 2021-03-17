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
            var jsonCars = File.ReadAllText("../../../Datasets/cars.json");


            var result = ImportParts(context, jsonCars);

            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
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
        }

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