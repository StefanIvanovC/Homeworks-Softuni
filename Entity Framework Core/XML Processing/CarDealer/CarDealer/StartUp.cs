using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.Models;
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

            var result = ImportParts(context, partsXmltext);

            System.Console.WriteLine(result);

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