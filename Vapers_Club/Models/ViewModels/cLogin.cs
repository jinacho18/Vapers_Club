using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cLogin
    {
        [Required]
        [Display(Name = "Usuario")]
        public int userusuario { set; get; }
        [Required]
        [Display(Name = "Contraseña")]
        public string ctrUsuario { set; get; }
    }
}