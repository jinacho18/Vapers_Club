using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cAlmacen
    {
        [Display(Name = "Id del Almacen")]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { set; get; }
        [Display(Name = "Direccion")]
        public string direccion { set; get; }
    }
}