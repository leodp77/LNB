using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public class PlayerPlayType: PlayType
    {
        [Key]
        public int PlayerPlayTypeId { get; set; }

        public virtual ICollection<PlayerPlay> PlayerPlays { get; set; }
    }
}