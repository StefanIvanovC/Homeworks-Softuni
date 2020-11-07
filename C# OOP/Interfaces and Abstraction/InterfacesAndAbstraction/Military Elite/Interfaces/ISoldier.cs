using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ISoldier
    {
        int Id { get; set; }

        string Name { get; set; }

        string LastName { get; set; }
    }
}
