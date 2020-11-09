using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Military_Elite.Interfaces
{
     public class IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
    }
}
