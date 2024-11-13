using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cAgregarCateg
    {
        [Required]
        [Display(Name = "Nombre de la Categoria")]
        public string nombre { set; get; }
    }
}