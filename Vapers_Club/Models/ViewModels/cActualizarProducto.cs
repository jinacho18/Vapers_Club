using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cActualizarProducto
    {
        public int id { set; get; }
        [Required]
        [Display(Name = "Producto")]
        public string nombre { set; get; }
        [Required]
        [Display(Name = "Marca")]
        public string marca { set; get; }
        [Required]
        [Display(Name = "Categoria")]
        public string categ { set; get; }
        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { set; get; }
        [Required]
        [Display(Name = "Precio")]
        public decimal precio { set; get; }
    }
}