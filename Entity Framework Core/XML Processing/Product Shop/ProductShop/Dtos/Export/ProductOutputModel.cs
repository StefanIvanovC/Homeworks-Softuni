using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductOutputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
        
    }
}

  //<name> Care One Hemorrhoidal</name>
  //<price>932.18</price>
  //<sellerId>25</sellerId>
  //<buyerId>24</buyerId>