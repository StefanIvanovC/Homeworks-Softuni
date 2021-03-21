using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class ImportCustomersInputModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
//{
//    "name": "Natalie Poli",
//    "birthDate": "1990-10-04T00:00:00",
//    "isYoungDriver": false
//  },