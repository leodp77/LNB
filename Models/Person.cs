using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNB.Models
{
    public abstract class Person
    {
        [Required]
        [Display(Name = "Nombre")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Ingrese un nombre de entre 2 y 20 caracteres")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Ingrese un apellido de provincia de entre 2 y 20 caracteres")]
        public string Surname { get; set; }

        [Display(Name = "Número de documento")]
        public string DocumentNumber { get; set; }

        
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "¿Se encuentra en actividad?")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "País")]
        public int CountryId { get; set; }

        
        [Display(Name = "Provincia / Estado")]
        public string Province { get; set; }

        
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        //public virtual City City { get; set; }
        public virtual Country Country { get; set; }

        public Person()
        {
            this.IsActive = true;
            this.DocumentNumber = "";
        }
    }
}