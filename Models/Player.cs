using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LNB.Models
{
    public class Player: Person
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [Display(Name="Peso (en kilogramos)")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Altura (en centímetros)")]
        public double Height { get; set; }

        [Display(Name="Apodo")]
        [StringLength(20, ErrorMessage="Ha superado el máximo de 20 caracteres")]
        public string NickName { get; set; }

        [Required]
        [Display(Name = "Posición principal en el campo")]
        public int PlayerPrincipalPositionId { get; set; }

        
        [Display(Name = "Posición secundaria en el campo")]
        public int? PlayerSecondaryPositionId { get; set; }

        public virtual ICollection<PlayerTeamRelationship> PlayerTeamRelationships { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual ICollection<PlayerPlay> PlayerPlays { get; set; }
        [ForeignKey("PlayerPrincipalPositionId")]
        public virtual PlayerPosition PlayerPrincipalPosition { get; set; }
        [ForeignKey("PlayerSecondaryPositionId")]
        public virtual PlayerPosition PlayerSecondaryPosition { get; set; }

        public Player()
        {
            this.NickName = "";

        }
    }
}