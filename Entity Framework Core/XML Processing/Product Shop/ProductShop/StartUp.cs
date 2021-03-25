using ProductShop.Data;
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

            var result = ImportCategories(context, categoriesXml);

            System.Console.WriteLine(result);
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

