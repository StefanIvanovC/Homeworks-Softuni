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
            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();

            //string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            //string inputJsonProducts = File.ReadAllText("../../../Datasets/products.json");
            //string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            //string inputJsonCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            //var resultUsers = ImportUsers(productShopContext, inputJsonUsers);
            //var resultProducts = ImportProducts(productShopContext, inputJsonProducts);
            //var resultCategories = ImportCategories(productShopContext, inputJsonCategories);
            //var resultCategoriesProducts = ImportCategoryProducts(productShopContext, inputJsonCategoriesProducts);

            var result = GetUsersWithProducts(productShopContext);

            Console.WriteLine(result);
        }

        // Query 7. Export Users and Products SOME BUGGY TASK

        //public static string GetUsersWithProducts(ProductShopContext context)
        //{
        //    var users = context.Users
        //        .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
        //        .Select(u => new
        //        {
        //            lastName = u.LastName,
        //            age = u.Age,
        //            soldProducts = new
        //            {
        //                count = u.ProductsSold.Count(),
        //                products = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
        //                {
        //                    name = p.Name,
        //                    price = p.Price
        //                })
        //            }
        //        })
        //        .OrderByDescending(x => x.soldProducts.Count())
        //        .ToList();

        //    var resultObject = new
        //    {
        //        usersCount = context.Users.Count(),
        //        users = users
        //    };

        //    var resultJson = JsonConvert.SerializeObject(resultObject);

        //    return resultObject;

        //{

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Count() == 0 ?
                                 0.ToString() :
                                 x.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var jsonresult = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonresult;
        }

        public static string GetSoldProducts(ProductShopContext context) //Query 6. Export Successfully Sold Products
        {
            var products = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName

                    })
                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonResult;
        }

        public static string GetProductsInRange(ProductShopContext context) // 05.Export
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
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
                .Where(x => x.Name != null)
                .ToList();

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