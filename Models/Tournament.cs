using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        [Required][Display(Name = "Apodo")]
        [StringLength(20, ErrorMessage = "Ha superado el máximo de 20 caracteres")]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Game> Games { get; set; }

    }
}
