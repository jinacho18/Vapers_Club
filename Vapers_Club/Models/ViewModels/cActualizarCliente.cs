using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cActualizarCliente
    {
        public int id { set; get; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { set; get; }
        [Required]
        [Display(Name = "Apellidos")]
        public string apellidos { set; get; }
        [Required]
        [Display(Name = "Correo Electronico")]
        public string correo { set; get; }
        [Required]
        [Display(Name = "Tipo de correo")]
        public int tipoc { set; get; }
        [Required]
        [Display(Name = "Telefono")]
        public int telefono { set; get; }
        [Required]
        [Display(Name = "Tipo de telefono")]
        public int tipot { set; get; }
    }
}