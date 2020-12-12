using Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string name, string lastname, decimal salary, HashSet<IPrivate> privates) 
            : base(id, name, lastname, salary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }

       
    }
}
