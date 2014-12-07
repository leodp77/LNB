using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class PlayerPosition
    {
        public int PlayerPositionId { get; set; }

        [Required]
        [Display(Name = "Nombre abreviado")]
        public string Abbreviation { get; set; }

        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        [InverseProperty("PlayerPrincipalPosition")]
        public virtual ICollection<Player> PrincipalPositionPlayers { get; set; }
        [InverseProperty("PlayerSecondaryPosition")]
        public virtual ICollection<Player> SecondaryPositionPlayers { get; set; }
    }
}
