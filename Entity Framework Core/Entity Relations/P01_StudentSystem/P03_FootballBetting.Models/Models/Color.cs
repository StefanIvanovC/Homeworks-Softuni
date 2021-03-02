using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Color // ColorId, Name
    {
        public int ColorId { get; set; }

        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; }

        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
