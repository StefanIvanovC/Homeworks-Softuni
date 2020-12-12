using System;
using System.Collections.Generic;
using System.Text;
using Military_Elite.Interfaces;

namespace Military_Elite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string name, string lastname)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
        }

        public int Id { get; }

        public string Name { get; }

        public string LastName { get; }

    }
}
