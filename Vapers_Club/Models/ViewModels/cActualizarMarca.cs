using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cActualizarMarca
    {
        public int id { set; get; }
        [Required]
        [Display(Name = "Nombre de la Marca")]
        public string nombre { set; get; }
    }
}