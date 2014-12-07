using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required][DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString="{0:dd-MM-yyyy a las hh:ss}", ApplyFormatInEditMode=true)]
        [Display(Name="Fecha")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Local")]
        public int HomeTeamId { get; set; }

        [Required]
        [Display(Name = "Visitante")]
        public int VisitorTeamId { get; set; }

        [Required]
        [Display(Name = "Estadio")]
        public int StadiumId { get; set; }

        [Required]
        [Display(Name = "Arbitro principal")]
        public int FirstRefereeId { get; set; }

        [Required]
        [Display(Name = "Arbitro secundario")]
        public int SecondRefereeId { get; set; }

        [Required]
        [Display(Name = "Arbitro tercero")]
        public int ThirdRefereeId { get; set; }

        //[Display(Name = "Torneo")]
        //public int TournamentId { get; set; }

        //public virtual Tournament Tournament{ get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team VisitorTeam { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Referee FirstReferee { get; set; }
        public virtual Referee SecondReferee { get; set; }
        public virtual Referee ThirdReferee { get; set; }

        public ICollection<TeamStatistic> TeamStatistics { get; set; }
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public ICollection<CoachStatistic> CoachStatistics { get; set; }
        public ICollection<PlayerPlay> PlayerPlays { get; set; }
        public ICollection<TeamPlay> TeamPlays { get; set; }


    }
}
