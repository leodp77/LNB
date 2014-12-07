using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class PlayerPlay: Play
    {
        [Key]
        public int PlayerPlayId { get; set; }

        [Required]
        [Display(Name = "Jugador")]
        public int PlayerId { get; set; }

        [Required]
        [Display(Name="Jugada")]
        public int PlayerPlayTypeId { get; set; }

        public virtual Player Player { get; set; }
        public virtual PlayerPlayType PlayerPlayType { get; set; }
    }
}