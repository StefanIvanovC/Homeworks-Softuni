using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree.Core
{
    public class Engine
    {
        private readonly iCollection<>
        
        public Engine()
        {

        }

        public void Run()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var personFor in peopleArgs)
            {
                string[] personArg = personFor.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personForRead = personArg[0];
                decimal personMoney = decimal.Parse(personArg[1]);

                Person person = new Person(personForRead,personMoney);

            }

            
        }

    }
}
