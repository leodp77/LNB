using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Stadium: Location
    {
        public int StadiumId { get; set; }

        [Required]
        [Display(Name = "Capacidad")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "País")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Provincia / Estado")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Dirección (calle y número)")]
        public string Address { get; set; }

        //public virtual City City { get; set; }
        public virtual ICollection<Game> Game { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual Country Country { get; set; }
    }
}
