using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public  class Citizen : IPerson , IBirthable, IIdentifiable
    {
        public Citizen(string name,int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public string Birthdate { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
