using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class TeamPlay: Play
    {
        [Key]
        public int TeamPlayId { get; set; }

        [Required]
        [Display(Name = "Equipo")]
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Jugada")]
        public int TeamPlayTypeId { get; set; }

        public virtual Team Team { get; set; }
        public virtual TeamPlayType TeamPlayType { get; set; }

    }
}