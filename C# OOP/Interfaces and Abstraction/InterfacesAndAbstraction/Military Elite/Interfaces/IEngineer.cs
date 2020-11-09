using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Military_Elite.Enumeration;

namespace Military_Elite.Interfaces
{
     public class IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
