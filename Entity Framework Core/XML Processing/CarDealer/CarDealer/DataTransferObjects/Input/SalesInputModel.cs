using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Input
{
    [XmlType("Sale")]
    public class SalesInputModel
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }
}

 //< Sale >
 //       < carId > 105 </ carId >
 //       < customerId > 30 </ customerId >
 //       < discount > 30 </ discount >
 //   </ Sale >
