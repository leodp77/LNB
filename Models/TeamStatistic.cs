using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class TeamStatistic: Statistic
    {
        public int TeamStatisticId { get; set; }
        
        [Required]
        [Display(Name = "Equipo")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }


    }
}
