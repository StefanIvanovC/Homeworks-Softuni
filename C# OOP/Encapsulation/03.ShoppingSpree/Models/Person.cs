using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private const string NotEnoughtMoneyMessage = "{0} can't afford {1}";
        private const string SuccesfulyBoughtMassage = "{0} bought {1}";
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
           
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.MoneyNegativeExcMsg);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)this.bag;
            }
            
        }

        public string BuyProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                return String.Format(NotEnoughtMoneyMessage, this.name, product.Name);
            }
            this.Money -= product.Cost;
            this.bag.Add(product);

            return String.Format(SuccesfulyBoughtMassage,this.name,product.Name);
        }

        public override string ToString()
        {
            string productOut = this.Bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {productOut}";
        }
    }
}
