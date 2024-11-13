using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cAgregarEvento
    {
        [Required]
        [Display(Name = "Fecha  Formato: YYYY-MM-DD HH-MM-SS")]
        public DateTime fecha { set; get; }
        [Required]
        [Display(Name ="Detalle")]
        public string detalle { set; get; }
    }
}