using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Input
{
    [XmlType("partId")]
    public class CarPartsInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

//< partId id = "102" />