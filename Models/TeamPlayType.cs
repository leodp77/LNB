using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class TeamPlayType: PlayType
    {
        [Key]
        public int TeamPlayTypeId { get; set; }

        public virtual ICollection<TeamPlay> TeamPlays { get; set; }
    }
}