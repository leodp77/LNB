using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public abstract class PlayType
    {
        [Required]
        [Display(Name = "Jugada")]
        public string Description { get; set; }

    }
}