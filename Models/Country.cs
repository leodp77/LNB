using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class Country : Location
    {
        public int CountryId { get; set; }
        //public virtual ICollection<Province> Provinces {get; set;}
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Referee> Referees { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Stadium> Stadiums { get; set; }
    }
}