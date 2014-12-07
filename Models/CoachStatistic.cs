using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class CoachStatistic : Statistic
    {
        public int CoachStatisticId { get; set; }

        [Required]
        [Display(Name = "Entrenador")]
        public int CoachId { get; set; }

        [Required]
        [Display(Name = "Faltas técnicas")]
        public int TechnicalFouls { get; set; }

        public virtual Coach Coach { get; set; }

    }
}
