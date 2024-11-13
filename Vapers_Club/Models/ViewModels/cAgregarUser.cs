using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cAgregarUser
    {
        [Required]
        [Display(Name ="Cedula")]
        public int cedula { set; get; }
        [Required]
        [Display(Name ="Contra")]
        public string contra { set; get; }
        [Required]
        [Display(Name = "Rol")]
        public int rol { set; get; }
    }
}