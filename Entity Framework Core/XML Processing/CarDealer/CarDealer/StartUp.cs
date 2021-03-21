using CarDealer.Data;
using CarDealer.Models;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var supplierExml = File.ReadAllText("supplier.xml");

            ;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml) 
        {
            return null;
        }
    }
}