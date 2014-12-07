using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LNB.Models
{
    public class Referee : Person
    {
        public int RefereeId { get; set; }

        //public virtual ICollection<Game> Games { get; set; }
        [InverseProperty("FirstReferee")]
        public virtual ICollection<Game> GamesAsFirstReferee { get; set; }
        [InverseProperty("SecondReferee")]
        public virtual ICollection<Game> GamesAsSecondReferee { get; set; }
        [InverseProperty("ThirdReferee")]
        public virtual ICollection<Game> GamesAsThirdReferee { get; set; }
    }
}
