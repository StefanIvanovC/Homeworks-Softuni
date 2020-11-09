using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Interfaces
{
    public interface ILieutenantGeneral 
    {
        ICollection<IPrivate> privates { get; set; }
    }
}
