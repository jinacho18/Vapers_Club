using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cAgregarAlmacen
    {
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { set; get; }
        [Required]
        [Display(Name = "Direccion")]
        public string direccion { set; get; }
    }
}