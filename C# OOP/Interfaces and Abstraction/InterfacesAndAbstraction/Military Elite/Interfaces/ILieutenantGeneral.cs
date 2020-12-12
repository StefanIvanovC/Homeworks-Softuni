using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Interfaces
{
    public interface ILieutenantGeneral 
    {
         public ICollection<IPrivate> Privates { get; }
    }
}
