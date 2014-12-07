using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class PlayerStatistic : Statistic
    {
        [Key]
        public int PlayerStatisticId { get; set; }


        public int PlayerId { get; set; }
        public int Minutes { get; set; }
        public int Points { get; set; }
        public int TwoPointsMade { get; set; }
        public int TwoPointsAttempt { get; set; }
        public int ThreePointsMade { get; set; }
        public int ThreePointsAttempt { get; set; }
        public int SinglePointsMade { get; set; }
        public int SinglePointsAttempt { get; set; }
        public int OffensiveRebounds { get; set; }
        public int DefensiveRebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }
        public int PersonalFouls { get; set; }
        public int TechnicalFouls { get; set; }
        public int FlagrantFouls { get; set; }
        public bool HasStarted { get; set; }

        public virtual Player Player { get; set; }

    }
}
