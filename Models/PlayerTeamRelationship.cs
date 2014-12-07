using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class PlayerTeamRelationship : Relationship
    {
        public int PlayerTeamRelationshipId { get; set; }

        [Required]
        [Display(Name="Jugador")]
        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Equipo")]
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Number { get; set; }
        
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }

    }
}
