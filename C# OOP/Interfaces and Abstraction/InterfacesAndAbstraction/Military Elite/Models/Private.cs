using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string name, string lastname, decimal salary) 
            : base(id, name, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; }
    }
}
