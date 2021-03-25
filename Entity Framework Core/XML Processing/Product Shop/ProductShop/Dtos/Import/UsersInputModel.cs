using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class UsersInputModel
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string lastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }
    }
}

//< firstName > Chrissy </ firstName >
//< lastName > Falconbridge </ lastName >
//< age > 50 </ age >