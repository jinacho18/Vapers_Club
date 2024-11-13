using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vapers_Club.Models.ViewModels
{
    public class cListaCliente
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public string apellidos { set; get; }
        public int telefono { set; get; }
        public string tipotel { set; get; }
        public string correo { set; get; }
        public string tipoco { set; get; }
    }
}