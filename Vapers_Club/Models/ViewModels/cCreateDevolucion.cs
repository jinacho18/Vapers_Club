using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cCreateDevolucion
    {
        [Required]
        [Display(Name = "Nombre")]
        public int cliente { set; get; }
        [Required]
        [Display(Name = "Nombre")]
        public int proveedor { set; get; }
        [Required]
        [Display(Name = "Razon")]
        public string razon { set; get; }
    }
}