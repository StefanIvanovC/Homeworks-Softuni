using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player // Player – PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int IsInjured { get; set; }

        public ICollection<PlayerStatistic> playerStatistics { get; set; }
    }
}
