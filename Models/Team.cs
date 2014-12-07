using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Display(Name = "Provincia")]
        public string Province { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Estadio")]
        public int StadiumId { get; set; }

        [Required]
        [Display(Name = "Nombre/Apodo")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Fecha de fundación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy}", ApplyFormatInEditMode=true)]
        public DateTime BirthDate { get; set; }



        //public virtual ICollection<Tournament> Tournament { get; set; }
        
        public virtual ICollection<PlayerTeamRelationship> PlayerTeamRelationships { get; set; }
                
        public virtual ICollection<CoachTeamRelationship> CoachTeamRelationships { get; set; }

        public virtual ICollection<TeamPlay> TeamPlays { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<TeamStatistic> TeamStatistics { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeTeamGames { get; set; }

        [InverseProperty("VisitorTeam")]
        public virtual ICollection<Game> VisitorTeamGames { get; set; }

        public virtual Stadium Stadium { get; set; }


    }
}
