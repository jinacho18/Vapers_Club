using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vapers_Club.Models.ViewModels
{
    public class cListaEntrega
    {
        public int id { set; get; }
        public DateTime fecha { set; get; }
        public String prodnomb { set; get; }
        public String estado { set; get; }
        public int cantidad { set; get; }
    }
}