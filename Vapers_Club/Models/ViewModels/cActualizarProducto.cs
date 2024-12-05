using System;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cActualizarProducto
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string marca { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public string categ { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required]
        [Display(Name = "Código")]
        public int codigo { get; set; }  

        [Required]
        [Display(Name = "Unidad de Medida")]
        public string unidadmedida { get; set; }  

        [Required]
        [Display(Name = "Vencimiento")]
        [DataType(DataType.Date)]  // Para un formato adecuado de fecha
        public DateTime vencimiento { get; set; }  

        [Required]
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
    }
}
