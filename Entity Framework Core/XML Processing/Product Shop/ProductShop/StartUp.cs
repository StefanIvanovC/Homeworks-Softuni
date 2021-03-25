using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.IO;
using System.Linq;
using XmlFacade;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var userXml = File.ReadAllText("../../../Datasets/users.xml");
            var productXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categorysProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            // var result = ImportCategoryProducts(context, categorysProductsXml);

            System.Console.WriteLine(GetProductsInRange(context));

           
        }

        public static string GetProductsInRange(ProductShopContext context) // Query 5. Products In Range
        {
            var root = "Products";
            //Get all products in a specified price range between 500 and 1000 (inclusive).
            //Order them by price (from lowest to highest).
            //Select only the product name, price and the full name of the buyer. Take top 10 records.
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)                
                .ToList();

            var result = XmlConverter.Serialize(products, root);

            return result;
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml) // Query 4. Import Categories and Products
        {
            var root = "CategoryProducts";

            var categorys = context.Categories.Select(c => c.Id).ToArray();
            var products = context.Products.Select(p => p.Id).ToArray();

            var categoryProductDto = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, root);

            var categoryProduct = categoryProductDto
                .Where(cp => categorys.Contains(cp.CategoryId) && products.Contains(cp.ProductId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToList();

            context.AddRange(categoryProduct);
            context.SaveChanges();

            var result = $"Successfully imported {categoryProduct.Count}";

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml) // Query 3. Import Categories
        {
            var root = "Categories";

            var categoriesDto = XmlConverter.Deserializer<CategoriesInputModel>(inputXml, root);

            var categories = categoriesDto
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToArray();

            context.AddRange(categories);
            context.SaveChanges();

            var result = $"Successfully imported {categories.Count()}";

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputXml) // Query 2. Import Products
        {
            var root = "Products";

            var productDto = XmlConverter.Deserializer<ProductsInputModel>(inputXml, root);

            var products = productDto
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                })
                .ToList();

            context.AddRange(products);
            context.SaveChanges();

            var result = $"Successfully imported {products.Count}";
            return result;
        }

        public static string ImportUsers(ProductShopContext context, string inputXml) // Query 1. Import Users
        {
            var root = "Users";

            var usersDto = XmlConverter.Deserializer<UsersInputModel>(inputXml, root);

            var users = usersDto.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.lastName,
                Age = x.Age
            })
            .ToList();

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}

