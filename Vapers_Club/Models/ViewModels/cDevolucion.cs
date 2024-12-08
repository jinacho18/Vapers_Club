using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cDevolucion
    {
        [Required]
        [Display(Name = "Id de la devolucion")]
        public int id { set; get; }
        [Required]
        [Display(Name = "Id del cliente")]
        public int cliente { set; get; }
        [Required]
        [Display(Name = "Nombre del Cliente")]
        public string ncliente { set; get; }
        [Required]
        [Display(Name = "Apellidos")]
        public string apellidos { set; get; }
        [Required]
        [Display(Name = "Id del proveedor")]
        public int proveedor { set; get; }
        [Required]
        [Display(Name = "Nombre del Proveedor")]
        public string nproveedor { set; get; }
        [Required]
        [Display(Name = "Razon")]
        public string razon { set; get; }
    }
}