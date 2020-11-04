using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> product;

        public Engine()
        {
            this.people = new List<Person>();
            this.product = new List<Product>();
        }

        public void Run()
        {

            try
            {
                this.ParsePeople();
                this.ParseProduct();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArg = command
                        .Split(" ").ToArray();
                    string personName = commandArg[0];
                    string productName = commandArg[1];

                    Person person = this.people.FirstOrDefault(person => person.Name == personName);
                    Product product = this.product.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string resuslt = person.BuyProduct(product);
                        Console.WriteLine(resuslt);
                    }

                    
                }

                foreach (var person in this.people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            
        }

        private void ParsePeople()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";").ToArray();
            foreach (var personFor in peopleArgs)
            {
                string[] personArg = personFor.Split("=").ToArray();
                string personForRead = personArg[0];
                decimal personMoney = decimal.Parse(personArg[1]);

                Person person = new Person(personForRead, personMoney);


                this.people.Add(person);
            }
        }

        private void ParseProduct()
        {
            string[] productsArgs = Console.ReadLine()
                .Split(";").ToArray();
            foreach (var productFor in productsArgs)
            {
                string[] productArg = productFor.Split("=").ToArray();
                string productName = productArg[0];
                decimal productCost = decimal.Parse(productArg[1]);

                Product product = new Product(productName, productCost);


                this.product.Add(product);
            }
        }

    }
}
