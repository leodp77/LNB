using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public abstract class Location
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El valor ingresado debe tener entre 2 y 20 caracteres")]
        public string Name { get; set; }
    }
}