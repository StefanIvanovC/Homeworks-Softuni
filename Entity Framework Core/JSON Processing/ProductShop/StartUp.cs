﻿using System;
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
            
            string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            string inputJsonCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            var resultUsers = ImportUsers(productShopContext, inputJsonUsers);
            var resultProducts = ImportProducts(productShopContext, inputJsonProducts);
            var resultCategories = ImportCategories(productShopContext, inputJsonCategories);
            var resultCategoriesProducts = ImportCategoryProducts(productShopContext, inputJsonCategoriesProducts);

            var result = resultCategories;

            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson) 
        {
            InitializeAutoMapper();

            var dtoCategoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var CatProdMapper = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProducts);

            context.AddRange(CatProdMapper);
            context.SaveChanges();

            return $"Successfully imported {CatProdMapper.Count()}";
        } //04.ImportCategoriesProducts

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dboCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null);

            var categoryMap = mapper.Map<IEnumerable<Category>>(dboCategories);

            context.AddRange(categoryMap);
            context.SaveChanges();

            return $"Successfully imported {categoryMap.Count()}";
        } // 03.ImportCategories

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