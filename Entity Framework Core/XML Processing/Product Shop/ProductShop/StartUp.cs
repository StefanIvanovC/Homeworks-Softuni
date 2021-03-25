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

            var result = ImportUsers(context, userXml);

            System.Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml) 
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

