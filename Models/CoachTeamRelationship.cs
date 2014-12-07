using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class CoachTeamRelationship: Relationship
    {
        public int CoachTeamRelationshipId { get; set; }

        [Required]
        [Display(Name = "Entrenador")]
        public int CoachId { get; set; }

        [Required]
        [Display(Name = "Equipo")]
        public int TeamId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual Team Team { get; set; }
    }
}