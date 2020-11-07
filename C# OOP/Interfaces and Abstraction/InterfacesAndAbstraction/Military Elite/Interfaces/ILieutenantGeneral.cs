using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> privates { get; set; }
    }
}
