//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vapers_Club.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class devoluciones
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public int proveedor { get; set; }
        public string razon { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual proveedores proveedores { get; set; }
    }
}
