using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class ImportSalesModel
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public int Discount { get; set; }
    }
}

//{
//    "carId": 105,
//    "customerId": 30,
//    "discount": 30
//  },