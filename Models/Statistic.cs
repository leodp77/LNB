using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public abstract class Statistic
    {
        [Required]
        [Display(Name = "Juego")]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
