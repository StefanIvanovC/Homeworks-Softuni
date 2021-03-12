using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {

        static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            productShopContext.Database.EnsureDeleted();
            productShopContext.Database.EnsureCreated();
            
            string inputJson = File.ReadAllText("../../../Datasets/users.json");
            var result = ImportProducts(productShopContext, inputJson);

            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson) // 02.ImportProducts
        {
            InitializeAutoMapper();

            var dtoProduct = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var productMap = mapper.Map<IEnumerable<Product>>(dtoProduct);

            context.Products.AddRange(productMap);
            context.SaveChanges();

            return $"Successfully imported {productMap.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson) // 01.ImportUsers
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var usersMap = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(usersMap);
            context.SaveChanges();

            return $"Successfully imported {usersMap.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}