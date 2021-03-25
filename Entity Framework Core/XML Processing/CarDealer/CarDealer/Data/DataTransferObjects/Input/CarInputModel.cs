using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Input
{
    [XmlType("Cars")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public int TraveledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartsInputModel[] CarPartsInputModel { get; set; }

    }
}

//< Car >
//    < make > Opel </ make >
//    < model > Omega </ model >
//    < TraveledDistance > 176664996 </ TraveledDistance >
//     < parts >
//       < partId id = "38" />
//       < partId id = "102" />
//     </ parts >
//  </ Car >
