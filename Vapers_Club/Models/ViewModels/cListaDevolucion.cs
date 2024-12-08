using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vapers_Club.Models.ViewModels
{
    public class cListaDevolucion
    {
        public int id { set; get; }
        public int idc { set; get; }
        public int idp { set; get; }
        public string ncliente { set; get; }
        public string apellidos { set; get; }
        public string nproveedor { set; get; }
        public string razon { set; get; }
    }
}