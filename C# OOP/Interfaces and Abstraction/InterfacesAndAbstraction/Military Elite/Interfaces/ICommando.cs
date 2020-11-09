using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Interfaces
{
    public interface ICommando 
    {
        ICollection<IMission> Missions { get; }
    }
}
