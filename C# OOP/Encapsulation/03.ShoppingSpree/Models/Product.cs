using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }     
        }

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.MoneyNegativeExcMsg);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
    
}
