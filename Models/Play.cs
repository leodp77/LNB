using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public abstract class Play
    {

        [Required]
        [Display(Name = "Partido")]
        public int GameId { get; set; }

        [Required]
        [Display(Name = "Minutos transcurridos")]
        public int Minutes { get; set; }

        [Required]
        [Display(Name = "Segundos transcurridos")]
        public int Seconds { get; set; }

        public virtual Game Game { get; set; }

    }
}