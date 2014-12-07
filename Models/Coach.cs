using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Coach: Person
    {
        public int CoachId { get; set; }

        public virtual ICollection<CoachTeamRelationship> CoachTeamRelationships { get; set; }
        public virtual ICollection<CoachStatistic> CoachStatistics { get; set; }
    }
}
